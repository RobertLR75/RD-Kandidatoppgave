using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Repository.Abstractions;
using Service.Abstractions;
using ServiceStack.Data;

namespace Service
{
    public class PersonService : BaseService, IPersonService
    {
        public PersonService(IPersonRepository repository, ILogger<BaseService> logger, IMemoryCache memoryCache) : base(logger, memoryCache)
        {
            PersonRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        private IPersonRepository PersonRepository { get; }
        public IPerson Get(int id)
        {
            var person = PersonRepository.Get(id);
            return person;

        }

    }
}
