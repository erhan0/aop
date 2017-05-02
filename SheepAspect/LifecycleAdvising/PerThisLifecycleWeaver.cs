//using System;
//using Mono.Cecil;
//using Mono.Cecil.Cil;
//using SheepAspect.Core;
//using SheepAspect.Helpers.CecilExtensions;
//using SheepAspect.Runtime;
//using SheepAspect.Runtime.Lifecycles;
//using System.Linq;

//namespace SheepAspect.LifecycleAdvising
//{
//    public class PerThisLifecycleWeaver: IWeaver
//    {
//        public const int PRIORITY = 901;

//        private readonly TypeDefinition _type;

//        private const string FieldName = "<>sac_aspectStore";

//        /// <summary>
//        /// Weavers with lower priority values will get processed earlier during compilation
//        /// This is useful to ensure certain weavers only get executed after all others, hence ensuring it will not get overruled by accident
//        /// Priority value of FlowAspectLifecycleWeaver is 900, so it will be executed later than other MethodWeaverBase (by default: 100)
//        /// </summary>
//        public int Priority
//        {
//            get { return PRIORITY; }
//        }

//        public PerThisLifecycleWeaver(TypeDefinition type)
//        {
//            _type = type;
//            Module = type.Module;
//        }

//        public void Weave()
//        {
//            MixinType();
//        }

//        public ModuleDefinition Module { get; private set; }

//        private void MixinType()
//        {
//            if (_type.Fields.Any(x => Equals(FieldName, x.Name)))
//                return;

//            var storeType = Module.Import(typeof(PerObjectAspectStore));
//            var storeField = new FieldDefinition(FieldName, FieldAttributes.Private, storeType);
//            _type.Fields.Add(storeField);
//            foreach(var con in _type.GetOrAddConstructors())
//            {
//                var conIl = con.Body.GetILProcessor();
//                con.Body.Instructions.Insert(0, conIl.Create(OpCodes.Ldarg_0));
//                con.Body.Instructions.Insert(1, conIl.Create(OpCodes.Newobj, Module.ImportConstructor<PerObjectAspectStore>()));
//                con.Body.Instructions.Insert(2, conIl.Create(OpCodes.Stfld, storeField));
//            }
            
//            _type.Interfaces.Add(Module.ImportType<IMayHaveAspect>());
            
//            BuildGetMethod(storeField);
//            BuildSetMethod(storeField);
//        }

//        private void BuildGetMethod(FieldDefinition storeField)
//        {
//            var getAspectMethod = new MethodDefinition("GetAspect",
//                                                       MethodAttributes.Private | MethodAttributes.NewSlot |
//                                                       MethodAttributes.Virtual | MethodAttributes.Final,
//                                                       Module.Import(typeof (object)));
//            _type.Methods.Add(getAspectMethod);
//            getAspectMethod.Overrides.Add(Module.ImportMethod<IMayHaveAspect>("GetAspect"));
//            var aspectTypeArg = new ParameterDefinition(Module.Import(typeof (Type)));
//            getAspectMethod.Parameters.Add(aspectTypeArg);

//            var il = getAspectMethod.Body.GetILProcessor();
//            il.Append(OpCodes.Ldarg_0);
//            il.Append(OpCodes.Ldfld, storeField);
//            il.Append(OpCodes.Ldarg, aspectTypeArg);
//            il.Append(OpCodes.Callvirt, Module.ImportMethod<PerObjectAspectStore>("Get"));
//            il.Append(OpCodes.Ret);
//        }

//        private void BuildSetMethod(FieldDefinition storeField)
//        {
//            var setAspectMethod = new MethodDefinition("BindAspect",
//                                                       MethodAttributes.Private | MethodAttributes.NewSlot |
//                                                       MethodAttributes.Virtual | MethodAttributes.Final,
//                                                       Module.Import(typeof(void)));
//            _type.Methods.Add(setAspectMethod);
//            setAspectMethod.Overrides.Add(Module.ImportMethod<IMayHaveAspect>("BindAspect"));
//            var aspectTypeArg = new ParameterDefinition(Module.Import(typeof(Type)));
//            setAspectMethod.Parameters.Add(aspectTypeArg);
//            var factoryArg = new ParameterDefinition(Module.Import(typeof(Func<object>)));
//            setAspectMethod.Parameters.Add(factoryArg);

//            var il = setAspectMethod.Body.GetILProcessor();
//            il.Append(OpCodes.Ldarg_0);
//            il.Append(OpCodes.Ldfld, storeField);
//            il.Append(OpCodes.Ldarg, aspectTypeArg);
//            il.Append(OpCodes.Ldarg, factoryArg);
//            il.Append(OpCodes.Callvirt, Module.ImportMethod<PerObjectAspectStore>("Bind"));
//            il.Append(OpCodes.Ret);
//        }
//    }
//}