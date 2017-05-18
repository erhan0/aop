using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace SheepAspect.Tasks
{
    public class PostCompileWeaveTask: Task 
    {
        [Required]
        public string ConfigFile { get; set; }
        
        /// <summary>
        /// Execute post compilation task.
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                var directoryPath = Path.GetDirectoryName(ConfigFile);
                string[] weavedFiles;
                var domain = AppDomain.CreateDomain("SheepAspect Weaving", null,
                        new AppDomainSetup
                            {
                                ApplicationBase = directoryPath,
                                ShadowCopyFiles = "true"
                            });

                try
                {
                    var runnerType = typeof (AppDomainIsolatedDiscoveryRunner);
                    
                    var runner = domain.CreateInstanceFromAndUnwrap(new Uri(runnerType.Assembly.CodeBase).LocalPath, runnerType.FullName) as
                                 AppDomainIsolatedDiscoveryRunner;

                    if (!runner.Process(ConfigFile, Log, out weavedFiles))
                    {
                        return false;
                    }
                }
                finally
                {
                    AppDomain.Unload(domain);
                }

                foreach (var file in weavedFiles)
                {
                    var sacName = AppDomainIsolatedDiscoveryRunner.TargetFileName(file);
                    File.Copy(sacName, file, true);
                    File.Delete(sacName);
                }
            }
            catch (Exception e)
            {
                Log.LogError(e.ToString());
                return false;
            }

            stopwatch.Stop();
            Log.LogMessage("[SheepAspect-Compiler] Compiled {0} in {1:n} ms", ConfigFile, stopwatch.ElapsedMilliseconds);
            return true;
        }
    }
}