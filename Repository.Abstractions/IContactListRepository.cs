using System.Collections;
using System.Collections.Generic;

namespace Repository.Abstractions
{
    public interface IContactListRepository
    {
        List<IPeople> GetContacts(int peopleId);
    }
}