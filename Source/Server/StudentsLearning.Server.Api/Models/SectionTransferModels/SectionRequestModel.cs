namespace StudentsLearning.Server.Api.Models.SectionTransferModels
{
    using Common;
    using System.ComponentModel.DataAnnotations;

    public class SectionRequestModel
    {
        [Required]
        [MinLength(ValidationConstants.MinStringLength)]
        [MaxLength(ValidationConstants.MaxTitleLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxDescriptionLength)]
        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}