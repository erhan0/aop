using System;
using System.Collections.Generic;
using Microsoft.Build.Utilities;
using SheepAspect.Compile;

namespace SheepAspect.Tasks
{
    public class AppDomainIsolatedDiscoveryRunner : MarshalByRefObject
    {
        public bool Process(string configFile, TaskLoggingHelper logger, out string[] weavedFiles)
        {
            weavedFiles = null;
            try
            {
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
                {
                    logger.LogError(inner.Message);
                }

                return false;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return false;
            }
        }

        public static string TargetFileName(string sourceFileName)
        {
            return sourceFileName + ".sac";
        }
    }
}