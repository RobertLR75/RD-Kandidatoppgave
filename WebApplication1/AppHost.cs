using System.Reflection;
using Funq;
using ServiceStack;
using ServiceStack.Api.OpenApi;
using ServiceStack.Api.Swagger;

namespace Service
{
    public class AppHost : AppHostBase
    {
        public AppHost(string serviceName, params Assembly[] assembliesWithServices) : base(serviceName, assembliesWithServices)
        {
        }

        public override void Configure(Container container)
        {
            var serviceInit = new AppHostCommon(this);
            serviceInit.Init();
            Plugins.Add(new OpenApiFeature
            {
                UseBasicSecurity = true,
            });
        }
    }
}
