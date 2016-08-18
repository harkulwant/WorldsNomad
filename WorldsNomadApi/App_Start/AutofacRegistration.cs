using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace WorldsNomadApi
{
    /// <summary>
    /// Autofac registration
    /// </summary>
    public static class AutofacRegistration
    {
        /// <summary>
        /// Register all modules, controllers and bindings
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<WorldsNomad.Logic.AutofacModule>();
            
            // Register Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}