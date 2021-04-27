using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Cors;
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

            UseCors(app);
            SwaggerConfig.Register(config);

            ConfigureAuth(app);
            // Web API routes
            WebApiConfig.Register(config);

            var kernel = new StandardKernel();

            kernel.Load(new ApiNinjectModule());


            app.UseSwagger(typeof(Startup).Assembly)
                .UseSwaggerUi3()
                .UseNinject(() => kernel)
                .UseNinjectWebApi(config);
        }

        private void UseCors(IAppBuilder app)
        {
            var corsPolicy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true
            };

            // Try and load allowed origins from web.config
            // If none are specified we'll allow all origins

                corsPolicy.AllowAnyOrigin = true;
            corsPolicy.Origins.Add("http://localhost:4200");

            var corsOptions = new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(corsPolicy)
                }
            };

            app.UseCors(corsOptions);
        }
    }
}
