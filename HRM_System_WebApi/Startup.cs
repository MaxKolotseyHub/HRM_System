using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using HRM_System_WebApi.Modules;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Ninject;
using NSwag.AspNet.Owin;
using Owin;

[assembly: OwinStartup(typeof(HRM_System_WebApi.Startup))]

namespace HRM_System_WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            SwaggerConfig.Register(config);

            ConfigureAuth(app);
            // Web API routes
            WebApiConfig.Register(config);

            var provide = new CorsPolicyProvider();
            provide.PolicyResolver = ctx => Task.FromResult(new System.Web.Cors.CorsPolicy { AllowAnyHeader = true, AllowAnyMethod = true, AllowAnyOrigin = true });

            var kernel = new StandardKernel();
            kernel.Load(new ApiNinjectModule());

            app.UseCors(new CorsOptions { PolicyProvider = provide });

            app.UseSwagger(typeof(Startup).Assembly)
                .UseSwaggerUi3()
                .UseNinject(() => kernel)
                .UseNinjectWebApi(config);
        }
    }
}
