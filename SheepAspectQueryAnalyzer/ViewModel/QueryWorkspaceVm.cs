using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using SheepAspectQueryAnalyzer.Common;
using SheepAspectQueryAnalyzer.Engine;
using SheepAspectQueryAnalyzer.Properties;
using SheepAspectQueryAnalyzer.Helpers;

namespace SheepAspectQueryAnalyzer.ViewModel
{
    public class QueryWorkspaceVm: WorkspaceVm
    {
        private readonly ICollection<string> _assemblyFileNames;

        public QueryWorkspaceVm(string name, ICollection<string> assemblyFileNames)
        {
            DisplayName = name;
            
            _assemblyFileNames = assemblyFileNames;
            _executeQueryCommand = new IconCommandVm(Texts.Command_ExecuteQuery, Images.Command_ExecuteQuery.ToImageSource(),
                x=> ExecuteQuery());
            _abortQueryCommand = new IconCommandVm(Texts.Command_AbortQuery, Images.Command_CancelQuery.ToImageSource(),
                x => AbortQuery());
            Commands.Add(_executeQueryCommand);

            _queryWorker = new BackgroundWorker{WorkerSupportsCancellation = true};
            _queryWorker.DoWork += DoQuery;
            _queryWorker.RunWorkerCompleted += delegate
                                                   {
                                                       Commands.Add(_executeQueryCommand);
                                                       Commands.Remove(_abortQueryCommand);
                                                   };
            
   
            Output = new QueryOutputVm();
            Result = new QueryResultVm();
        }

        private void AbortQuery()
        {
            _queryWorker.CancelAsync();
            Commands.Add(_executeQueryCommand);
            Commands.Remove(_abortQueryCommand);
        }

        private void DoQuery(object sender, DoWorkEventArgs e)
        {
            var txt = RequestSelectedQueryText();
            if (string.IsNullOrEmpty(txt))
            {
                txt = QueryText;
            }

            var runner = new QueryRunner(Result, Application.Current.Dispatcher);
            using (var logWriter = Output.StartStopwatchWriter())
            {
                runner.Run(_assemblyFileNames, txt, logWriter);
            }
        }

        protected QueryOutputVm QueryOutput { get; private set; }

        private void ExecuteQuery()
        {
            Commands.Remove(_executeQueryCommand);
            Commands.Add(_abortQueryCommand);

            _queryWorker.RunWorkerAsync();
        }

        private string _queryText = "";
        private readonly IconCommandVm _executeQueryCommand;
        private readonly IconCommandVm _abortQueryCommand;
        private readonly BackgroundWorker _queryWorker;

        public string QueryText
        {
            get { return _queryText; }
            set 
            {
                _queryText = value;
                OnPropertyChanged("QueryText");
            }
        }

        public QueryOutputVm Output { get; private set; }
        public QueryResultVm Result { get; private set; }

        #region View-Bound Events
        public event Func<string> RequestSelectedQueryText;
        #endregion
    }
}