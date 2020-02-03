using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Repository.Abstractions;
using Service.Requests;
using Service.Responses;
using ServiceStack;

namespace Service.Endpoints
{
    public class PeopleService : BaseService
    {

        public PeopleService(IPeopleRepository personRepository, ILogger<BaseService> logger, IMemoryCache memoryCache) : base(logger, memoryCache)
        {
            PersonRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
        }

        private IPeopleRepository PersonRepository { get; }
        //Example endpoint
        public PersonResponse Get(PersonRequest request)
        {
            var result = GetCache<IPeople>(CacheModuleKey.People, request.Id.ToString());

            if (result == null)
            {
                result = PersonRepository.Get(request.Id);

                if (result == null)
                    throw HttpError.NotFound($"'{request.Id}' is not a person");
            }

            AddCache(result, CacheModuleKey.People, request.Id.ToString());

            var person = new PersonResponse
            {
            }.PopulateWith(result); //Populates with matching fields
            
            return person;
        }
    }
}
