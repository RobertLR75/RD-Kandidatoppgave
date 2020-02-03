using System;
using System.Collections.Generic;
using System.Text;
using Repository.Abstractions;

namespace Repository
{
    
    public class Enterprise : IEnterprise
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
