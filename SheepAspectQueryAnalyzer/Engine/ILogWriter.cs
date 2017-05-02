using System;

namespace SheepAspectQueryAnalyzer.Engine
{
    public interface ILogWriter : IDisposable
    {
        void Append(string text, params object[] args);
    }
}