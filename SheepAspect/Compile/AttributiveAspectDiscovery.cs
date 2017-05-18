using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SheepAspect.Core;
using SheepAspect.Framework;

namespace SheepAspect.Compile
{
    public class AttributiveAspectDiscovery : IAspectDiscovery
    {
        private readonly CompilerSettings _settings;
        private readonly AttributiveAspectProvider _provider = new AttributiveAspectProvider();

        public AttributiveAspectDiscovery(CompilerSettings settings)
        {
            _settings = settings;
        }

        public IEnumerable<AspectDefinition> DiscoverAspects()
        {
            var assemblies = _settings.AspectAssemblyFiles.Select(a=> Assembly.LoadFrom(Path.Combine(_settings.BaseDirectory, a))).AsParallel();

            return assemblies.SelectMany(a => a.GetTypes())
                .SelectMany(AllPublicTypesInHierarchy)
                .Select(_provider.GetDefinition)
                .Where(x => x != null);
        }

        private static IEnumerable<Type> AllPublicTypesInHierarchy(Type type)
        {
            if(!type.IsPublic)
            {
                yield break;
            }

            yield return type;
            foreach(var t in type.GetNestedTypes().SelectMany(AllPublicTypesInHierarchy))
            {
                yield return t;
            }
        }
    }
}