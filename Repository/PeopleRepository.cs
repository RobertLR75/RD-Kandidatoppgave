using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Abstractions;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Repository
{
    public class PeopleRepository : BaseRepository, IPeopleRepository
    {
        public PeopleRepository(IDatabase database, IDbConnectionFactory dbFactory) : base(database, dbFactory)
        {
            EnterpriseRepository = new EnterpriseRepository(database, dbFactory);
            ContactListRepository = new ContactListRepository(database, dbFactory);
        }

        private IEnterpriseRepository EnterpriseRepository { get; }
        private IContactListRepository ContactListRepository { get; }

        public IPeople Get(int id)
        {
            using (var db = DbFactory.Open())
            {
                var people = db.Select<People>("SELECT Id, Name, EnterpriseId FROM people where Id = " + id).FirstOrDefault();

                if (people != null)
                {

                    if (people.EnterpriseId > 0)
                        people.Enterprise = EnterpriseRepository.Get(people.EnterpriseId);

                    people.Contacts = ContactListRepository.GetContacts(id);
                }

                return people;
            }
        }
    }
}
