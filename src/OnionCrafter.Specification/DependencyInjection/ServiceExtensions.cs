using Microsoft.Extensions.DependencyInjection;
using OnionCrafter.Base.Services;
using OnionCrafter.Specification.Repository.Cache;
using OnionCrafter.Specification.UnitOfWork;

namespace OnionCrafter.Specification.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositoryFactory(this IServiceCollection services, Action<UnitOfWorkOptions> unitOfWorkOptions, Action<RepositoryContainerOptions> repositoryContainerOptions)
        {
            services.AddTypedSingletonWithOptions<RepositoryContainerOptions>(typeof(IRepositoryContainer), typeof(RepositoryContainer), repositoryContainerOptions);
            services.AddTypedSingletonWithOptions<UnitOfWorkOptions>(typeof(IUnitOfWork<>), typeof(UnitOfWork<>), unitOfWorkOptions);
            return services;
        }
        public static IServiceCollection AddRepositoryFactory(this IServiceCollection services, Action<UnitOfWorkOptions> unitOfWorkOptions)
        {
            services.AddTypedSingleton(typeof(IRepositoryContainer), typeof(RepositoryContainer));
            services.AddTypedSingletonWithOptions<UnitOfWorkOptions>(typeof(IUnitOfWork<>), typeof(UnitOfWork<>), unitOfWorkOptions);
            return services;
        }
        public static IServiceCollection AddRepositoryFactory(this IServiceCollection services)
        {
            services.AddTypedSingleton(typeof(IRepositoryContainer), typeof(RepositoryContainer));
            services.AddTypedSingleton(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            return services;
        }
    }
}