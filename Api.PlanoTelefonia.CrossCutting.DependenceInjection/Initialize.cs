using Api.PlanoTelefonia.BussinesLogic;
using Api.PlanoTelefonia.CrossCutting.DependenceInjection;
using Api.PlanoTelefonia.DataAccess;
using SimpleInjector.Integration.Web;
using System;
using System.Linq;

namespace Api.PlanoTelefonia.CrossCutting.DependenceInjetion
{
    public class Initialize
    {
        public static SimpleInjector.Container Container { get; set; }

        /// <summary>Create container</summary>
        public static void ConfigureContainer(bool singleton = false)
        {
            var lifeStyle = singleton ? SimpleInjector.Lifestyle.Singleton : SimpleInjector.Lifestyle.Scoped;
			// 2. Configure the container (register) Data Access

			Container.Options.ConstructorResolutionBehavior = new MostResolvableConstructorBehavior(Container);
            Container.Register<IDatabaseContextPlanoTelefonia, DatabaseContextPlanoTelefonia>(lifeStyle);

			//----

			Container.Register<IQueryStackPlanoTelefonia, QueryStackPlanoTelefonia>(lifeStyle);
            Container.Register<ICommandStackPlanoTelefonia, CommandStackPlanoTelefonia>(lifeStyle);
			
			Container.Register<IPlanoTelefoniaBll, PlanoTelefoniaBll>(lifeStyle);


            // IMPORTANTE: O namespace da classe de negócio deverá ser:
            // Api.PlanoTelefonia.BusinessLogic
            //var businessAssembly = typeof(BaseBll).Assembly;

            //var registrations =
            //    from type in businessAssembly.GetExportedTypes()
            //    where type.Namespace == "Api.PlanoTelefonia.BusinessLogic"
            //        && !type.IsAbstract
            //        && !type.Name.StartsWith("IValidator")
            //    where type.GetInterfaces().Any()
            //        && !type.Name.StartsWith("IValidator")
            //    select new { Service = type.GetInterfaces().First(), Implementation = type };

            //foreach (var reg in registrations)
            //{
            //    if (!reg.Service.Name.StartsWith("IValidator"))
            //        Container.Register(reg.Service, reg.Implementation, lifeStyle);
            //}

        }

        /// <summary>Create container</summary>
        public static void CreateContainer(bool singleton = false)
        {
            // 1. Create a new Simple Injector container
            Container = new SimpleInjector.Container();
            // https://simpleinjector.readthedocs.io/en/latest/lifetimes.html#webrequest

            if (!singleton)
                Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
        }

        public static void InitScoped()
        {
            CreateContainer(false);
            ConfigureContainer(false);
            VerifyContainer();
        }

        public static void InitSingleton()
        {
            CreateContainer(true);
            ConfigureContainer(true);
            VerifyContainer();
        }

        public static T Instance<T>(Type entity)
        {
            return (T)Container.GetInstance(entity);
        }

        public static void VerifyContainer()
        {
            // 3. Verify your configuration
            Container.Verify();
        }
    }
}