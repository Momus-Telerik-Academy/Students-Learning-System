namespace StudentsLearning.Server.Api.Models.TopicTransferModels
{
    #region

    using System.Collections.Generic;

    using StudentsLearning.Server.Api.Models.CommentTransferModels;
    using StudentsLearning.Server.Api.Models.ContributorTransferModels;
    using StudentsLearning.Server.Api.Models.ExampleTransferModels;
    using StudentsLearning.Server.Api.Models.ZipFileTransferModels;

    #endregion

    public class TopicResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string VideoId { get; set; }

        public int SectionId { get; set; }

        public ICollection<ZipFileResponseModel> ZipFiles { get; set; }

        public ICollection<ExampleResponseModel> Examples { get; set; }

        public ICollection<CommentResponseModel> Comments { get; set; }

        public ICollection<ContributorResponseModel> Contributors { get; set; }
    }
}