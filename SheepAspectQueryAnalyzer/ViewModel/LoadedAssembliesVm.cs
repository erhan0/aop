using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Win32;
using SheepAspectQueryAnalyzer.Common;
using System.Linq;
using SheepAspectQueryAnalyzer.Properties;

namespace SheepAspectQueryAnalyzer.ViewModel
{
    public class LoadedAssembliesVm: ViewModelBase
    {
        private readonly ICollection<string> _assemblies;
        private readonly ObservableCollection<AssemblyVm> _assembliesVm;

        public LoadedAssembliesVm(ICollection<string> assemblies)
        {
            _assemblies = assemblies;
            _assembliesVm = new ObservableCollection<AssemblyVm>(assemblies.Select(x => new AssemblyVm(x, Remove)).ToList());
            Assemblies = new ReadOnlyObservableCollection<AssemblyVm>(_assembliesVm);

            AddCommand = new CommandVm(Texts.Command_AddAssemblies, x=> Add());
            DoneCommand = new CommandVm(Texts.Command_Done, x=> Close());
            
        }

        public CommandVm AddCommand { get; private set; }
        public CommandVm DoneCommand { get; private set; }
        
        public void Add()
        {
            var dialog = new OpenFileDialog
                             {
                                 Filter = "Assembly Files (*.dll,*.exe)|*.dll;*.exe",
                                 Multiselect = true
                             };
            if(dialog.ShowDialog() == true)
            {
                foreach(var file in dialog.FileNames)
                {
                    _assemblies.Add(file);
                    _assembliesVm.Add(new AssemblyVm(file, Remove));
                }
            }
        }

        private void Remove(AssemblyVm asm)
        {
            _assemblies.Remove(asm.FileName);
            _assembliesVm.Remove(asm);
        }

        public event Action OnCloseRequested;
        private void Close()
        {
            if (OnCloseRequested != null)
                OnCloseRequested();
        }

        public ReadOnlyObservableCollection<AssemblyVm> Assemblies { get; private set; }

        public class AssemblyVm
        {
            public AssemblyVm(string assemblyFilename, Action<AssemblyVm> removeAction)
            {
                FileName = assemblyFilename;
                RemoveCommand = new ActionCommand(x=> removeAction(this));
            }

            public string FileName { get; private set; }

            public ICommand RemoveCommand { get; private set; }
        }
    }

    
}