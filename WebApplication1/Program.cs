namespace Service
{
    public class Program : SelfhostBase
    {
        public static int Main(string[] args)
        {
            return StartService<Startup>(args);
        }
    }
}
