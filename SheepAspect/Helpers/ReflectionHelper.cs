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
                var propertyInfo = namedArgument.MemberInfo as PropertyInfo;
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(attribute, namedArgument.TypedValue.Value, null);
                }
                else
                {
                    var fieldInfo = namedArgument.MemberInfo as FieldInfo;
                    if (fieldInfo != null)
                    {
                        fieldInfo.SetValue(attribute, namedArgument.TypedValue.Value);
                    }
                }
            }

            return attribute;
        }
    }
}