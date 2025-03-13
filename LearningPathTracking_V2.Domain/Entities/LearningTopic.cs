using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPathTracking_V2.Domain.Enums;

namespace LearningPathTracking_V2.Domain.Entities
{
    public class LearningTopic
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Progress { get; set; } = 0;
        public TopicStatus Status { get; set; } = TopicStatus.NotStarted;
    }
}
