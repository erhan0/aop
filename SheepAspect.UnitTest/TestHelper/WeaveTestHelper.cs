using System;
using System.IO;
using System.Reflection;
using Mono.Cecil;
using SheepAspect.Compile;
using SheepAspect.Core;

namespace SheepAspect.UnitTest.TestHelper
{
    public static class WeaveTestHelper
    {
        public static object WeaveAndLoadType(Type fixtureType, AspectDefinition aspect, Type typeToLoad)
        {
            File.Delete(GetWeavedDllName(fixtureType));

            var name = fixtureType.Name;
            var compiler =
                new AspectCompiler(new CompilerSettings
                {
                    TargetAssemblyFiles = { Assembly.GetCallingAssembly().GetName().Name + ".dll" }
                })
                {
                    AssemblyNameTransform =
                        x => new AssemblyNameDefinition(x.Name + "_" + name, new Version()),
                    FileNameTransform = f => Path.GetFileNameWithoutExtension(f) + "_" + name + ".dll"
                };

            compiler.Weave(new[]{aspect});
            return CreateTarget(fixtureType, typeToLoad);
        }

        public static object CreateTarget(Type fixtureType, Type typeToLoad)
        {
            return AppDomain.CurrentDomain.CreateInstanceFromAndUnwrap(GetWeavedDllName(fixtureType), typeToLoad.FullName);
        }

        private static string GetWeavedDllName(Type testFixture)
        {
            return Path.GetFileNameWithoutExtension(new Uri(testFixture.Assembly.CodeBase).AbsolutePath) + "_" + testFixture.Name + ".dll";
        }
    }
}