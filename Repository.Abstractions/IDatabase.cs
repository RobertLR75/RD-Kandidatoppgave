using System.Collections.Generic;
using ServiceStack.Data;

namespace Repository.Abstractions
{
    public interface IDatabase
    {
        void CreateTablesAndTestData(IDbConnectionFactory dbFactory);

        List<string> ExampleData(IDbConnectionFactory dbFactory);
    }
}