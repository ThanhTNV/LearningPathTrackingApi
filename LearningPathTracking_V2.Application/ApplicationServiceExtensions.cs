using LearningPathTracking_V2.Application.Interfaces;
using LearningPathTracking_V2.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LearningPathTracking_V2.Application
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services
            services.AddScoped<ILearningTopicService, LearningTopicService>();

            return services;
        }
    }
}
