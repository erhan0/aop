using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SheepAspect.Compile
{
    public class CompilerSettings
    {
        private readonly ICollection<string> _targetAssemblyFiles = new Collection<string>();
        private readonly ICollection<string> _aspectAssemblyFiles = new Collection<string>();

        public CompilerSettings()
        {
            BaseDirectory = "";
        }

        public ICollection<string> TargetAssemblyFiles
        {
            get { return _targetAssemblyFiles; }
        }

        public ICollection<string> AspectAssemblyFiles
        {
            get { return _aspectAssemblyFiles; }
        }

        public string BaseDirectory { get; set; }
    }
}