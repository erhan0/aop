using System;
using System.Linq;
using System.Reflection;

namespace SheepAspect.Helpers
{
    public static class ReflectionHelper
    {
        public static Attribute CreateAttribute(this CustomAttributeData data)
        {
            var arguments = from arg in data.ConstructorArguments
                            select arg.Value;

            var attribute = data.Constructor.Invoke(arguments.ToArray())
              as Attribute;

            foreach (var namedArgument in data.NamedArguments)
            {
                if (namedArgument.MemberInfo is PropertyInfo propertyInfo)
                {
                    propertyInfo.SetValue(attribute, namedArgument.TypedValue.Value, null);
                }
                else
                {
                    if (namedArgument.MemberInfo is FieldInfo fieldInfo)
                    {
                        fieldInfo.SetValue(attribute, namedArgument.TypedValue.Value);
                    }
                }
            }

            return attribute;
        }
    }
}