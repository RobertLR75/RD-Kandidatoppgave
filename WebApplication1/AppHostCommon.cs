using Funq;
using Microsoft.Extensions.Caching.Memory;
using Repository;
using Repository.Abstractions;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Service
{
    public class AppHostCommon
    {
        protected Container Container;
        public AppHostCommon(ServiceStackHost self)
        {
            Container = self.Container;
        }

        public void Init()
        {
            SetupDatabase();
        }

        private void SetupDatabase()
        {

            var connectionFactory = new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider);
            Container.Register<IDbConnectionFactory>(c => connectionFactory);
            
            var db = new Repository.Database();
            db.CreateTablesAndTestData(connectionFactory);
            Container.RegisterAutoWiredAs<Repository.Database, Repository.Abstractions.IDatabase>();
            Container.RegisterAutoWiredAs<MemCache, IMemoryCache>();
            Container.RegisterAutoWiredAs<PeopleRepository, IPeopleRepository>();

        }

    }
}
