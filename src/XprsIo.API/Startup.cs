using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using SimpleInjector.Extensions.ExecutionContextScoping;

namespace XprsIo.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        private readonly Container _container = new Container();
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddInstance<IControllerActivator>(new SimpleInjectorControllerActivator(_container));
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeApplication(app);
            RegisterControllers(app);

            _container.Verify(VerificationOption.VerifyAndDiagnose);

            app.Use(async (context, next) =>
            {
                using (_container.BeginExecutionContextScope())
                {
                    await next();
                }
            });
            
            app.UseMvc();
        }

        private void InitializeApplication(IApplicationBuilder app)
        {
            Bootstrap.InitializeContainer(_container, app);
            BusinessLayer.Bootstrap.InitializeContainer(_container);
            DataAccessLayer.Bootstrap.InitializeContainer(_container);
        }

        private void RegisterControllers(IApplicationBuilder app)
        {
            var provider = app.ApplicationServices.GetRequiredService<IControllerTypeProvider>();
            foreach (var type in provider.ControllerTypes)
            {
                var registration = Lifestyle.Transient.CreateRegistration(type, _container);
                _container.AddRegistration(type, registration);
                registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "ASP.NET disposes controllers.");
            }
        }
    }
}
