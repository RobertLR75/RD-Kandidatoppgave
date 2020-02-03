using System;
using System.Collections.Generic;
using System.Text;
using Repository.Abstractions;

namespace Repository
{
    public class People : IPeople
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EnterpriseId { get; set; }
        public IEnterprise Enterprise { get; set; }
        public ICollection<IPeople> Contacts { get; set; }
    }
}
