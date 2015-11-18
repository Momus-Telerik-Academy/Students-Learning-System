namespace StudentsLearning.Server.Api.Models.CommentTransferModels
{
    using System.ComponentModel.DataAnnotations;

    public class CommentRequestModel
    {
        [Required]
        public string Content { get; set; }

        public int TopicId { get; set; }
    }
}