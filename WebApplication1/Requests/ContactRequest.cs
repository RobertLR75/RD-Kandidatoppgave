using ServiceStack;

namespace Service.Requests
{
    [Route("/persons/{id}/contacts", "GET")]
    public class ContactRequest
    {
        public int Id { get; set; }
    }

    
}
