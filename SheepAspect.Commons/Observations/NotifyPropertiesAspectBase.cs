using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using SheepAspect.Framework;
using SheepAspect.Runtime;
using SheepAspect.Helpers;
using System.Linq;

namespace SheepAspect.Commons.Observations
{
    [AspectPerThis(ActivateOnPointcut = "OnGetSet")]
    public abstract class NotifyPropertiesAspectBase
    {
        protected abstract void TargetTypes();

        private readonly ThreadLocal<Stack<PropertyInfo>> _getterStack = new ThreadLocal<Stack<PropertyInfo>>(() => new Stack<PropertyInfo>(1));
        private readonly IDictionary<FieldInfo, IList<PropertyInfo>> _fieldDependents = new Dictionary<FieldInfo, IList<PropertyInfo>>();

        [Around]
        [SelectProperties("Public & InType:@TargetTypes")]
        public virtual object OnGetSet(PropertyJointPoint jp)
        {
            try
            {
                _getterStack.Value.Push(jp.Property);
                return jp.Execute();
            }
            finally
            {
                _getterStack.Value.Pop();
            }
        }

        [Around]
        [SelectGetFields("FromProperty:InType:@TargetTypes | FromMethod:InType:@TargetTypes")]
        public virtual object OnFieldGet(GetFieldJointPoint jp)
        {
            var dependents = DependentsOf(jp.Field);
            foreach (var property in _getterStack.Value)
            {
                dependents.Add(property);
            }

            return jp.Execute();
        }

        [Around]
        [SelectSetFields("FromProperty:InType:@TargetTypes | FromMethod:InType:@TargetTypes")]
        public virtual void OnFieldSet(SetFieldJointPoint jp)
	    {
		    if(jp.Target == jp.This)
		    {
			    OnChanged((INotifyPropertyChanged) jp.This, jp.Field);

                PropertyChangedEventHandler evHandler = (o, e) => OnChanged((INotifyPropertyChanged)jp.This, jp.Field);

                if (jp.Value is INotifyPropertyChanged observable)
                {
                    observable.PropertyChanged += evHandler;
                }

                if (jp.Field.GetValue(jp.This) is INotifyPropertyChanged originalObservable)
                {
                    originalObservable.PropertyChanged -= evHandler;
                }
            }
		    jp.Execute();
	    }

        protected virtual void OnChanged(INotifyPropertyChanged inpc, FieldInfo field)
	    {
		    foreach(var prop in DependentsOf(field))
            {
                Trigger(inpc, prop);
            }
        }

        protected virtual void Trigger(INotifyPropertyChanged inpc, PropertyInfo prop)
        {
            foreach (var handler in inpc.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(f => f.FieldType == typeof(PropertyChangedEventHandler))
                .Select(f=> (PropertyChangedEventHandler)f.GetValue(inpc)).Where(x=> x!=null))
            {
                handler(inpc, new PropertyChangedEventArgs(prop.Name));
            }
        }

        private IList<PropertyInfo> DependentsOf(FieldInfo field)
        {
            return _fieldDependents.GetOrPut(field, () => new List<PropertyInfo>());
        }
    }
}