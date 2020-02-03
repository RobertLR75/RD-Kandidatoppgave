using System.Collections.Generic;

namespace Service.Responses
{
    public class PersonResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EnterpriseResponse Enterprise { get; set; }
    }

    
}
