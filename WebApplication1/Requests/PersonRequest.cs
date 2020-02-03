using ServiceStack;

namespace Service.Requests
{
    [Route("/persons/{id}", "GET")]
    public class PersonRequest
    {
        public int Id { get; set; }
    }

    
}
