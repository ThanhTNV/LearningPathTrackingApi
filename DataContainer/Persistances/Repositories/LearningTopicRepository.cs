using System.Linq.Expressions;
using LearningPathTracking_V2.Application.DTOs.LearningTopic;
using LearningPathTracking_V2.Domain.Entities;
using LearningPathTracking_V2.Domain.Enums;
using LearningPathTracking_V2.Domain.Interfaces;

namespace DataContainer.Persistances.Repositories
{
    public class LearningTopicRepository : ILearningTopicRepository
    {
        private List<LearningTopic> _topicContainer;
        public LearningTopicRepository()
        {
            _topicContainer = new List<LearningTopic>();
        }

        async Task<LearningTopic?> IRepository<LearningTopic>.CreateOne(LearningTopic obj)
        {
            await Task.Delay(100);
            var newTopic = new LearningTopic
            {
                Id = _topicContainer.ToArray().Length + 1,
                Name = obj.Name,
                Progress = obj.Progress,
                Status = obj.Status
            };
            _topicContainer.Add(newTopic);
            return _topicContainer.FirstOrDefault(newTopic);
        }

        async Task<LearningTopic?> IRepository<LearningTopic>.DeleteOne(Expression<Func<LearningTopic, bool>> predicate)
        {
            await Task.Delay(100);
            var result = _topicContainer.AsQueryable().FirstOrDefault(predicate.Compile());
            if(result is not null)
            {
                _topicContainer.Remove(result);
            }
            return result;
        }

        async Task<IEnumerable<LearningTopic>> IRepository<LearningTopic>.GetAllAsync()
        {
            await Task.Delay(100);
            return _topicContainer;
        }

        async Task<LearningTopic?> IRepository<LearningTopic>.GetOne(Expression<Func<LearningTopic, bool>> predicate)
        {
            await Task.Delay(100);
            return _topicContainer.AsQueryable().FirstOrDefault(predicate.Compile());
        }

        async Task<LearningTopic?> IRepository<LearningTopic>.UpdateOne(Expression<Func<LearningTopic, bool>> predicate, object updateDto)
        {
           if(updateDto is not UpdateLearningTopicDto topicDto) return null;
            
            return await UpdateTopic(predicate, topicDto);
        }

        async Task<LearningTopic?> UpdateTopic(Expression<Func<LearningTopic, bool>> predicate, UpdateLearningTopicDto updateDto)
        {
            var exisitingTopic = _topicContainer.AsQueryable().FirstOrDefault(predicate.Compile());
            if (exisitingTopic is null) 
                return null;
            if(updateDto.Name is not null)
                exisitingTopic.Name = updateDto.Name;
            if(updateDto.Progress is not null)
                exisitingTopic.Progress = (int)updateDto.Progress;
            if(updateDto.Status is not null)
                exisitingTopic.Status = (TopicStatus)updateDto.Status;
            await Task.Delay(100);
            return exisitingTopic;
        }
    }
}
