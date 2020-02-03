using System.Collections.Generic;

namespace Service.Responses
{
    public class ContactResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<ContactResponse> Contacts { get; set; }
    }

    
}
