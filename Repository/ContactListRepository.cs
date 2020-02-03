using System.Collections.Generic;
using System.Linq;
using Repository.Abstractions;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Repository
{
    public class ContactListRepository : BaseRepository, IContactListRepository
    {
        public ContactListRepository(IDatabase database, IDbConnectionFactory dbFactory) : base(database, dbFactory)
        {
            EnterpriseRepository = new EnterpriseRepository(database, dbFactory);
        }

        private IEnterpriseRepository EnterpriseRepository { get; }

        public List<IPeople> GetContacts(int peopleId)
        {
            using (var db = DbFactory.Open())
            {
                var contactList = db.Select<People>("SELECT People.Id, People.Name, People.EnterpriseId FROM People " +
                                                   " join ContactList on ContactList.ContactId = People.Id " +
                                                   "where ContactList.PeopleId = " + peopleId).ToList();

                foreach (var contact in contactList)
                {
                    contact.Enterprise = EnterpriseRepository.Get(contact.EnterpriseId);
                }

                return contactList.Cast<IPeople>().ToList();
            }
        }
    }
}