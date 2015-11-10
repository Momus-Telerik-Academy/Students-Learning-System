namespace StudentsLearning.Server.Api.Models
{
    using System.Collections.Generic;

    public class TopicRequestModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string VideoId { get; set; }

        public int SectionId { get; set; }

       // public int? ZipFileId { get; set; }

        public ICollection<ExampleRequestModel> Examples { get; set; }

        public ICollection<CommentRequestModel> Comments { get; set; }
    }
}