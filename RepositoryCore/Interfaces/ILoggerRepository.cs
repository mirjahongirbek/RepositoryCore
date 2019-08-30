﻿using System;
using System.Runtime.CompilerServices;

namespace RepositoryCore.Interfaces
{
    public interface ILoggerCore
    {
        void StartFunction(string text, long time, object obj, string methodName,
            [CallerLineNumber] int linenumber = 0);

        void Logging(string text, long time, object obj, string methodName, [CallerLineNumber] int linenumber = 0);

        void CatchError(string text, long time, object obj, Exception exception, string methodName, string GUID,
            [CallerLineNumber] int linenumber = 0);
    }
}
