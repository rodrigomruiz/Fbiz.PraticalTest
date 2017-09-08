[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Fbiz.PraticalTest.Store.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Fbiz.PraticalTest.Store.App_Start.NinjectWebCommon), "Stop")]

namespace Fbiz.PraticalTest.Store.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Fbiz.PraticalTest.Application.Interface;
    using Fbiz.PraticalTest.Domain.Interfaces.Services;
    using Fbiz.PraticalTest.Domain.Interfaces.Repositories;
    using Fbiz.PraticalTest.Application;
    using Fbiz.PraticalTest.Domain.Services;
    using Fbiz.PraticalTest.Infra.Data.Repositories;

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
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<ICategoryAppService>().To<CategoryAppService>();
            kernel.Bind<IProductAppService>().To<ProductAppService>();
            kernel.Bind<ICommentAppService>().To<CommentAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<ICommentService>().To<CommentService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<ICommentRepository>().To<CommentRepository>();
        }        
    }
}
