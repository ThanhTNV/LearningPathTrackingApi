using System.Linq.Expressions;
using LearningPathTracking_V2.Application.DTOs.LearningTopic;
using LearningPathTracking_V2.Domain.Entities;
using LearningPathTracking_V2.Domain.Enums;
using LearningPathTracking_V2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LearningPathTracking_V2.Infrastructure.Persistances.Repositories
{
    public class LearningTopicRepository : ILearningTopicRepository
    {
        private LearningDbContext _context;
        public LearningTopicRepository(LearningDbContext context)
        {
            _context = context;
        }

        async Task<LearningTopic?> IRepository<LearningTopic>.CreateOne(LearningTopic obj)
        {
            var res = await _context.LearningTopics.AddAsync(obj);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        async Task<LearningTopic?> IRepository<LearningTopic>.DeleteOne(Expression<Func<LearningTopic, bool>> predicate)
        {
            var existingTopic = await _context.LearningTopics.FirstOrDefaultAsync(predicate);
            if(existingTopic is not null)
            {
                _context.LearningTopics.Remove(existingTopic);
                await _context.SaveChangesAsync();
            }
            return existingTopic;
        }

        async Task<IEnumerable<LearningTopic>> IRepository<LearningTopic>.GetAllAsync()
        {
            return await _context.LearningTopics.ToListAsync();
        }

        async Task<LearningTopic?> IRepository<LearningTopic>.GetOne(Expression<Func<LearningTopic, bool>> predicate)
        {
            return await _context.LearningTopics.FirstOrDefaultAsync(predicate);
        }

        async Task<LearningTopic?> IRepository<LearningTopic>.UpdateOne(Expression<Func<LearningTopic, bool>> predicate, object updateDto)
        {
           if(updateDto is not UpdateLearningTopicDto topicDto) return null;
            
            return await UpdateTopic(predicate, topicDto);
        }

        async Task<LearningTopic?> UpdateTopic(Expression<Func<LearningTopic, bool>> predicate, UpdateLearningTopicDto updateDto)
        {
            var existingTopic = await _context.LearningTopics.FirstOrDefaultAsync(predicate);
            if (existingTopic is null)
                return null;
            if (updateDto.Name is not null)
                existingTopic.Name = updateDto.Name;
            if (updateDto.Progress is not null)
                existingTopic.Progress = (int)updateDto.Progress;
            if (updateDto.Status is not null)
                existingTopic.Status = (TopicStatus)updateDto.Status;

            var res = _context.LearningTopics.Update(existingTopic);
            await _context.SaveChangesAsync();
            return res.Entity;
        }
    }
}
