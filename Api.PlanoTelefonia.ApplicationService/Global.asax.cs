using Newtonsoft.Json.Serialization;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Api.PlanoTelefonia.ApplicationService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Configure Formatters
            // https://stackoverflow.com/questions/25224824/how-to-change-default-web-api-2-to-json-formatter
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());

            // Configure Camelcase Properties
            // https://stackoverflow.com/questions/22130431/web-api-serialize-properties-starting-from-lowercase-letter
            GlobalConfiguration
                .Configuration
                .Formatters
                .JsonFormatter
                .SerializerSettings
                .ContractResolver = new CamelCasePropertyNamesContractResolver();

            GlobalConfiguration.Configuration.Routes
                                .MapHttpRoute("Default",
                                "{controller}/{id}",
                                new { id = RouteParameter.Optional }
                                );

            // Configure Dependence Injection
            // Install: SimpleInjector.Integration.webapi
            CrossCutting.DependenceInjetion.Initialize.InitScoped();

            // This is an extension method from the integration package.
            // CrossCutting.DependenceInjetion.Initialize.Container.regiRegisterWebApiControllers(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(CrossCutting.DependenceInjetion.Initialize.Container);

            // Configure AutoMapper
            CrossCutting.Mapping.Initialize.Init();

        }
    }
}
