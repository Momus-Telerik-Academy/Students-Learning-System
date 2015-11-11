﻿namespace StudentsLearning.Server.Api.Models
{
    using System.Collections.Generic;

    public class SectionResponsetModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<TopicResponseMinifiedModel> Topics { get; set; }
    }
}