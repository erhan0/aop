using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SheepAspect.Compile
{
    public class CompilerSettings
    {
        private readonly ICollection<string> targetAssemblyFiles = new Collection<string>();
        private readonly ICollection<string> aspectAssemblyFiles = new Collection<string>();

        public CompilerSettings()
        {
            BaseDirectory = "";
        }

        public ICollection<string> TargetAssemblyFiles
        {
            get { return targetAssemblyFiles; }
        }

        public ICollection<string> AspectAssemblyFiles
        {
            get { return aspectAssemblyFiles; }
        }

        public string BaseDirectory { get; set; }
    }
}