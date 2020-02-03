using System;
using System.Collections.Generic;
using System.Text;
using Repository.Abstractions;

namespace ServiceTest
{
    public class People : IPeople
    {
        public People()
        {
            Enterprise = new Enterprise();
            Contacts = new List<IPeople>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnterprise Enterprise { get; set; }
        public ICollection<IPeople> Contacts { get; set; }
    }

    public class Enterprise : IEnterprise
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
