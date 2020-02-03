using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Abstractions;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Repository
{
    public class EnterpriseRepository : BaseRepository, IEnterpriseRepository
    {
        public EnterpriseRepository(IDatabase database, IDbConnectionFactory dbFactory) : base(database, dbFactory)
        {
        }


        public IEnterprise Get(int id)
        {
            using (var db = DbFactory.Open())
            {
                var enterprise = db.Select<Enterprise>("SELECT * FROM ENTERPRISE where Id = " + id).FirstOrDefault();
                return enterprise;
            }
        }
    }
}
