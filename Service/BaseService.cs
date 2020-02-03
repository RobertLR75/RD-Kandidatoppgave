using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Repository.Abstractions;
using ServiceStack.Data;

namespace Service
{
    public class BaseService
    {
        protected readonly IDatabase Database;
        protected readonly IDbConnectionFactory DbFactory;
        protected ILogger<BaseService> Logger;
        protected IMemoryCache MemoryCache;
        public BaseService(ILogger<BaseService> logger, IMemoryCache memoryCache )
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            MemoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }
    }
}
