using LearningPathTracking_V2.Domain.Interfaces;
using LearningPathTracking_V2.Infrastructure.Persistances.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LearningPathTracking_V2.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructureConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ILearningTopicRepository, LearningTopicRepository>();
            return services;
        }
    }
}
