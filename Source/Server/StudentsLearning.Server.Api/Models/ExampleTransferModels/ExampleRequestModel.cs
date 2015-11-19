using StudentsLearning.Common;

namespace StudentsLearning.Server.Api.Models.ExampleTransferModels
{
    using System.ComponentModel.DataAnnotations;

    public class ExampleRequestModel
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxTitleLength)]
        public string Content { get; set; }

        // public int TopicId { get; set; }
    }
}