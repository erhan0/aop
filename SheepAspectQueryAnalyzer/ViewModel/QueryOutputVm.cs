using System.Diagnostics;
using SheepAspectQueryAnalyzer.Common;
using SheepAspectQueryAnalyzer.Engine;
using SheepAspectQueryAnalyzer.Properties;

namespace SheepAspectQueryAnalyzer.ViewModel
{
    public class QueryOutputVm: ViewModelBase
    {
        public QueryOutputVm()
        {
            ClearCommand = new CommandVm(Texts.Command_ClearQueryOutput, x => Clear());
        }

        public ILogWriter StartStopwatchWriter()
        {
            return new StopwatchWriter(this);
        }

        protected void Append(string text)
        {
            Text += text + "\r\n";
        }

        public CommandVm ClearCommand { get; private set; }

        private void Clear()
        {
            Text = "";
        }

        private string _text = "";
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        private class StopwatchWriter : ILogWriter
        {
            private readonly Stopwatch _stopwatch;
            private readonly QueryOutputVm _vm;

            public StopwatchWriter(QueryOutputVm vm)
            {
                _vm = vm;
                _stopwatch = new Stopwatch();
                _stopwatch.Start();
            }

            public void Append(string text, params object[] args)
            {
                _vm.Append(string.Format("[ms: {0}] {1}", _stopwatch.Elapsed.Milliseconds, string.Format(text, args)));
            }

            public void Dispose()
            {
                _stopwatch.Stop();
            }
        }
    }


}