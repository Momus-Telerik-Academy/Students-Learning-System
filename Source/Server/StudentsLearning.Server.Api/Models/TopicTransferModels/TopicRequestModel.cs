namespace StudentsLearning.Server.Api.Models.TopicTransferModels
{
    #region

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using StudentsLearning.Server.Api.Models.CommentTransferModels;
    using StudentsLearning.Server.Api.Models.ExampleTransferModels;
    using StudentsLearning.Server.Api.Models.ZipFileTransferModels;
    using Common;

    #endregion

    public class TopicRequestModel
    {
        [Required]
        [MinLength(ValidationConstants.MinStringLength)]
        [MaxLength(ValidationConstants.MaxTitleLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxContentLength)]
        public string Content { get; set; }

        [Required]
        public string VideoId { get; set; }

        public int SectionId { get; set; }

        public ICollection<ExampleRequestModel> Examples { get; set; }
    }
}