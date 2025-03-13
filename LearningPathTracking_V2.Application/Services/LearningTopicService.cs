using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPathTracking_V2.Application.DTOs.LearningTopic;
using LearningPathTracking_V2.Application.Interfaces;
using LearningPathTracking_V2.Domain.Entities;
using LearningPathTracking_V2.Domain.Interfaces;

namespace LearningPathTracking_V2.Application.Services
{
    public class LearningTopicService : ILearningTopicService
    {
        private ILearningTopicRepository _repository;
        public LearningTopicService(ILearningTopicRepository repository)
        {
            _repository = repository;   
        }
        async Task<LearningTopic?> ILearningTopicService.CreateLearningTopic(CreateLearningTopicDto topicDto)
        {
            var result = await _repository.CreateOne(new LearningTopic
            {
                Name = topicDto.Name,
                Progress = topicDto.Progress,
                Status = topicDto.Status
            });
            return result;
        }

        async Task<LearningTopic?> ILearningTopicService.DeleteLearningTopic(int id)
        {
            return await _repository.DeleteOne(topic => topic.Id == id);
        }

        async Task<IEnumerable<LearningTopic>> ILearningTopicService.GetAllTopics()
        {
            return await _repository.GetAllAsync();
        }

        async Task<LearningTopic?> ILearningTopicService.GetOneLearningTopic(int id)
        {
            return await _repository.GetOne(topic => topic.Id == id);
        }

        async Task<LearningTopic?> ILearningTopicService.UpdateLearningTopic(int id, UpdateLearningTopicDto topicDto)
        {
            return await _repository.UpdateOne(topic => topic.Id == id, topicDto);
        }
    }
}
