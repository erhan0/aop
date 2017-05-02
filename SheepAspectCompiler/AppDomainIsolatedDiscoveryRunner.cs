using System;
using System.Collections.Generic;
using System.IO;
using SheepAspect.Compile;

namespace SheepAspectCompiler
{
    public class AppDomainIsolatedDiscoveryRunner: MarshalByRefObject
    {
        public bool Process(string configFile, out string[] weavedFiles)
        {
            weavedFiles = null;
            try
            {
                //var assembly = Assembly.LoadFile(assemblyFile);
                //var discovery = new PointcutMatcherDiscovery(assembly, namespacePattern, name => Path.GetDirectoryName(name) + @"\aopTemp\" + Path.GetFileName(name));
                //discovery.Process();

                var settings = new XmlCompilerSettings(configFile);
                var disco = new AttributiveAspectDiscovery(settings);

                var files = new List<string>();
                new AspectCompiler(settings)
                    {
                        FileNameTransform = name =>
                                                {
                                                    files.Add(name);
                                                    return TargetFileName(name);
                                                }
                    }.Weave(disco);

                weavedFiles = files.ToArray();
                return true;
            }
            catch (AggregateException e)
            {
                foreach (var inner in e.InnerExceptions)
                    Console.Error.WriteLine(inner.Message);
                return false;
            }
            catch(Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return false;
            }
        }

        public static string TargetFileName(string sourceFileName)
        {
            return Path.GetFileNameWithoutExtension(sourceFileName) + "_sac_" + Path.GetExtension(sourceFileName);
        }
    }
}