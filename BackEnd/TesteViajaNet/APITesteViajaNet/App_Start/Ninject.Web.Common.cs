[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(APITesteViajaNet.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(APITesteViajaNet.App_Start.NinjectWebCommon), "Stop")]

namespace APITesteViajaNet.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using DominioTesteViajaNet.Interfaces.Repositorios;
    using DominioTesteViajaNet.Interfaces.Servicos;
    using DominioTesteViajaNet.Servicos;
    using InfraTesteViajaNet.Repositorio;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Ninject.Web.WebApi;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IBaseServico<>)).To(typeof(BaseServico<>));
            kernel.Bind<IClienteServico>().To<ClienteServico>();
            kernel.Bind<IDadosNavegacaoServico>().To<DadosNavegacaoServico>();
            kernel.Bind<IDadosPagamentoServico>().To<DadosPagamentoServico>();
            kernel.Bind<IEnderecoServico>().To<EnderecoServico>();
            kernel.Bind<ILandingServico>().To<LandingServico>();

            kernel.Bind(typeof(IBaseRepositorio<>)).To(typeof(BaseRepositorio<>));
            kernel.Bind<IClienteRepositorio>().To<ClienteRepositorio>();
            kernel.Bind<IDadosNavegacaoRepositorio>().To<DadosNavegacaoRepositorio>();
            kernel.Bind<IDadosPagamentoRepositorio>().To<DadosPagamentoRepositorio>();
            kernel.Bind<IEnderecoRepositorio>().To<EnderecoRepositorio>();
            kernel.Bind<ILandingRepositorio>().To<LandingRepositorio>();
        }        
    }
}