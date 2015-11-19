namespace StudentsLearning.Server.Api.Models.CategoryTransferModels
{
    using System.ComponentModel.DataAnnotations;
    using StudentsLearning.Common;

    public class CategoryRequestModel
    {
        [Required]
        [MinLength(ValidationConstants.MinStringLength)]
        [MaxLength(ValidationConstants.MaxTitleLength)]
        public string Name { get; set; }
    }
}