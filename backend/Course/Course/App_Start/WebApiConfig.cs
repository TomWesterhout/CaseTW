using AutoMapper;
using Course.Configuration;
using Course.Data.Interface;
using Course.Data.Repository;
using Course.Services;
using Course.Services.Interface;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.Lifetime;

namespace Course
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            UnityContainer container = new UnityContainer();
            container.RegisterType<ICursusRepository, CursusRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICursusInstantieRepository, CursusInstantieRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITextFileToObjectConverterService, TextFileToObjectConverterService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITextFileToAttributeConverterService, TextFileToAttributeConverterService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITextFileValidationService, TextFileValidationService>(new HierarchicalLifetimeManager());
            // Automapper configuration and registration
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            container.RegisterInstance<IMapper>(mapperConfiguration.CreateMapper());

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Necessary to enable a connection with the Angular application on a local level.
            var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors(cors);

            // Forces the WebApi to return JSON in stead of XML.
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            jsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
        }
    }
}
