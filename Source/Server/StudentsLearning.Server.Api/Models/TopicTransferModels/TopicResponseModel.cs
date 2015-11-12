namespace StudentsLearning.Server.Api.Models.TopicTransferModels
{
    using System.Collections.Generic;
    using StudentsLearning.Server.Api.Models.CommentTransferModels;
    using StudentsLearning.Server.Api.Models.ExampleTransferModels;

    public class TopicResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string VideoId { get; set; }

        public int SectionId { get; set; }

        public int? ZipFileId { get; set; }

        public ICollection<ExampleResponseModel> Examples { get; set; }

        public ICollection<CommentResponseModel> Comments { get; set; }
    }
}