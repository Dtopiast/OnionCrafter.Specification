using Microsoft.Extensions.DependencyInjection;
using OnionCrafter.Base.Utils;
using OnionCrafter.Service.DependencyInjection;
using OnionCrafter.Specification.Repositories.General;
using OnionCrafter.Specification.Repositories.General.Options;

namespace OnionCrafter.Specification.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepository<TOptions>(this IServiceCollection services, Type repositoryService, Type repositoryImplementation, Action<TOptions>? options = null)
            where TOptions : class, IBaseRepositoryOptions
        {
            TypeExtensions.EnsureValidImplement(repositoryService, typeof(IBaseRepository));
            if (options != null)
                services.AddTypedScoped(repositoryService, repositoryImplementation, options);
            else
                services.AddTypedScoped(repositoryService, repositoryImplementation);
            return services;
        }
    }
}