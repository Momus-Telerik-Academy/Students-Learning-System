using System.Collections.Generic;

namespace StudentsLearning.Server.Api.Models
{
    public class TopicResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string VideoId { get; set; }

        public int SectionId { get; set; }

       // public int? ZipFileId { get; set; }

        public ICollection<ExampleResponseModel> Examples { get; set; }

        public ICollection<CommentResponseModel> Comments { get; set; }
    }
}