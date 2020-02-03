using System;
using System.Collections.Generic;
using System.Text;
using Repository.Abstractions;
using ServiceStack.Data;

namespace Repository
{

    public class BaseRepository
    {
        public BaseRepository(IDatabase database, IDbConnectionFactory dbFactory)
        {
            Database = database ?? throw new ArgumentNullException(nameof(database));
            DbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        protected readonly IDatabase Database;
        protected readonly IDbConnectionFactory DbFactory;

    }
}
