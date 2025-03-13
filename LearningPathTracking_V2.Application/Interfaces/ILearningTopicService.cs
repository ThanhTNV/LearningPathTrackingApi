using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPathTracking_V2.Application.DTOs.LearningTopic;
using LearningPathTracking_V2.Domain.Entities;

namespace LearningPathTracking_V2.Application.Interfaces
{
    public interface ILearningTopicService
    {
        Task<IEnumerable<LearningTopic>> GetAllTopics();
        Task<LearningTopic?> GetOneLearningTopic(int id);
        Task<LearningTopic?> UpdateLearningTopic(int id, UpdateLearningTopicDto topicDto);
        Task<LearningTopic?> CreateLearningTopic(CreateLearningTopicDto topicDto);
        Task<LearningTopic?> DeleteLearningTopic(int id);
    }
}
