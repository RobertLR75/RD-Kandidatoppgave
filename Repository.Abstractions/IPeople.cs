using System.Collections.Generic;

namespace Repository.Abstractions
{
    public interface IPeople
    {
        int Id { get; set; }
        string Name { get; set; }
        IEnterprise Enterprise { get; set; }

        ICollection<IPeople> Contacts { get; set; }
    }

  
}