#region

using StudentsLearning.Server.Api.App_Start;

using WebActivatorEx;

#endregion

namespace StudentsLearning.Server.Api.App_Start
{
    #region

    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using StudentsLearning.Data;
    using StudentsLearning.Data.Repositories;

    #endregion

    public static class NinjectConfig
    {
        public static Action<IKernel> DependenciesRegistration = kernel =>
        {
            kernel.Bind<IStudentsLearningDbContext>().To<StudentsLearningDbContext>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));
        };

        public static IKernel CreateKernel()
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
        ///     Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            DependenciesRegistration(kernel);

            kernel.Bind(b => b.From("StudentsLearning.Services.Data")
                .SelectAllClasses()
                .BindDefaultInterface());

            kernel.Bind(b => b.From("StudentsLearning.Services.GoogleDrive")
                            .SelectAllClasses()
                            .BindDefaultInterface());
        }
    }
}
