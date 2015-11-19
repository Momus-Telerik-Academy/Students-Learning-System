namespace StudentsLearning.Server.Api.Models.CommentTransferModels
{
    using System.ComponentModel.DataAnnotations;
    using StudentsLearning.Common;

    public class CommentRequestModel
    {
        [Required]
        [MinLength(ValidationConstants.MinStringLength)]
        [MaxLength(ValidationConstants.MaxContentLength)]
        public string Content { get; set; }

        public int TopicId { get; set; }
    }
}