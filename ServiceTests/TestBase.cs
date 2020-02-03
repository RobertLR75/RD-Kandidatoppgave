using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Service;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using Xunit.Abstractions;

namespace ServiceTest
{
    public class TestBase
    {
        public TestBase(ITestOutputHelper output)
        {
            //var connectionFactory = new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider);
            //var db = new Repository.Database();
            //db.CreateTablesAndTestData(connectionFactory);
            Logger = new XUnitLogger<BaseService>(output);
            Cache = new MemCache();
        }

        protected ILogger<BaseService> Logger { get; }
        protected IMemoryCache Cache { get; }

    }

    public class XUnitLogger<T> : ILogger<T>, IDisposable
    {
        private readonly ITestOutputHelper _output;

        public XUnitLogger(ITestOutputHelper output)
        {
            _output = output;
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _output.WriteLine(state.ToString());
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public void Dispose()
        {
        }
    }
}
