using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPathTracking_V2.Domain.Enums;

namespace LearningPathTracking_V2.Application.DTOs.LearningTopic
{
    public class UpdateLearningTopicDto
    {
        public string? Name { get; set; }
        public int? Progress { get; set; }
        public TopicStatus? Status { get; set; }
    }
}
