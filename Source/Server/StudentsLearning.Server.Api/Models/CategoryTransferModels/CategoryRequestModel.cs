namespace StudentsLearning.Server.Api.Models.CategoryTransferModels
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryRequestModel
    {
        [Required]
        public string Name { get; set; }
    }
}