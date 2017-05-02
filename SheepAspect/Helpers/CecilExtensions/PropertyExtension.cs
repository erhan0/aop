using Mono.Cecil;

namespace SheepAspect.Helpers.CecilExtensions
{
    public static class PropertyExtension
    {
         public static bool IsStatic(this PropertyDefinition self)
         {
             return ((self.GetMethod != null && self.GetMethod.IsStatic) ||
                     (self.SetMethod != null && self.SetMethod.IsStatic));
         }
    }
}