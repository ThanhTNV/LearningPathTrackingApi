using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContainer.Persistances.Repositories;
using LearningPathTracking_V2.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataContainer
{
    public static class DataContainerExtensions
    {
        public static IServiceCollection AddDataContainer(this IServiceCollection services)
        {
            services.AddScoped<ILearningTopicRepository, LearningTopicRepository>();
            return services;
        }
    }
}
