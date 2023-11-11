using System;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace ShtrihM.Wattle3.Examples.Common;

public class NUnitConsoleLoggerProvider : ILoggerProvider
{
    #region NUnitConsoleLogger

    private class NUnitConsoleLogger : ILogger
    {
        #region Private Class StubScope
        private class StubScope : IDisposable
        {
            public void Dispose()
            {
                /* NONE */
            }
        }
        #endregion

        private readonly string m_categoryName;
        private readonly NUnitConsoleLoggerProvider m_owner;

        public NUnitConsoleLogger(string categoryName, NUnitConsoleLoggerProvider owner)
        {
            m_categoryName = categoryName;
            m_owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (m_owner.m_suppressOutput)
            {
                return;
            }

            TestContext.Progress.WriteLine($"{m_categoryName} : {formatter(state, exception)}");
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new StubScope();
        }
    }
    #endregion

    private readonly bool m_suppressOutput;

    public NUnitConsoleLoggerProvider(bool suppressOutput = false)
    {
        m_suppressOutput = suppressOutput;
    }

    public void Dispose()
    {
        /* NONE */
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new NUnitConsoleLogger(categoryName, this);
    }

    public void Add(ILoggingBuilder builder)
    {
        builder.AddProvider(this);
        builder.AddFilter<NUnitConsoleLoggerProvider>(null, LogLevel.Trace);
    }
}