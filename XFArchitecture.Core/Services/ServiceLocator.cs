using System;

using Autofac;

using XFArchitecture.Core.ViewModels.Home;
using XFArchitecture.Core.Services.General;
using XFArchitecture.Core.Contracts.General;
using XFArchitecture.Core.Services.Database;
using XFArchitecture.Core.Contracts.Database;
using XFArchitecture.Core.Services.Repository;
using XFArchitecture.Core.Contracts.Repository;

namespace XFArchitecture.Core.Services
{
    public class ServiceLocator
    {
        private IContainer container { get; set; }
        private ContainerBuilder containerBuilder { get; set; }

        public static ServiceLocator Instance { get; } = new ServiceLocator();
        public ServiceLocator()
        {
            containerBuilder = new ContainerBuilder();

            //ViewModels
            containerBuilder.RegisterType<HomeViewModel>();

            //Services
            containerBuilder.RegisterType<DialogService>().As<IDialogService>();
            containerBuilder.RegisterType<LoadingService>().As<ILoadingService>();
            containerBuilder.RegisterType<NetworkService>().As<INetworkService>();
            containerBuilder.RegisterType<DatabaseService>().As<IDatabaseService>();
            containerBuilder.RegisterType<RepositoryService>().As<IRepositoryService>();
        }

        public T Resolve<T>() => container.Resolve<T>();

        public void Build() => container = containerBuilder.Build();

        public object Resolve(Type type) => container.Resolve(type);

        public void Register<T>() where T : class => containerBuilder.RegisterType<T>();

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface => containerBuilder.RegisterType<TImplementation>().As<TInterface>();
    }
}