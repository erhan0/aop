using System;
using System.IO;

namespace SheepAspectCompiler
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                //var configFile = args[0];
                var configFile = @"D:\Dev\Codeplex\SheepAop\SheepAspect.Examples\3_ShoppingCartAutoAlert\bin\debug\SheepAspect.config";   

                var directoryPath = Path.GetDirectoryName(configFile);

                string[] weavedFiles;
                var domain = AppDomain.CreateDomain("SheepAspect Weaving", null, directoryPath, directoryPath, true);
                try
                {
                    //var runnerType = typeof(AppDomainIsolatedDiscoveryRunner);
                    //var runner = domain.CreateInstanceFromAndUnwrap(
                    //        new Uri(runnerType.Assembly.CodeBase).AbsolutePath, runnerType.FullName) as AppDomainIsolatedDiscoveryRunner;

                    var runner = new AppDomainIsolatedDiscoveryRunner();
                    if (!runner.Process(configFile, out weavedFiles))
                        return 1;
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
                Console.Error.WriteLine(e);
                return 1;
            }
            return 0;
        }
    }
}
