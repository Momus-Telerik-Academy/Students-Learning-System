namespace StudentsLearning.Server.Api.Models.TopicTransferModels
{
    using System.Collections.Generic;

    using StudentsLearning.Server.Api.Models.CommentTransferModels;
    using StudentsLearning.Server.Api.Models.ContributorTransferModels;
    using StudentsLearning.Server.Api.Models.ExampleTransferModels;
    using StudentsLearning.Server.Api.Models.ZipFileTransferModels;

    public class TopicRequestModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string VideoId { get; set; }

        public int SectionId { get; set; }

        public ICollection<ZipFileRequestModel> ZipFiles { get; set; }

        public ICollection<ExampleRequestModel> Examples { get; set; }

        public ICollection<CommentRequestModel> Comments { get; set; }

        //public ICollection<ContributorRequestModel> Contributors { get; set; }
    }
}