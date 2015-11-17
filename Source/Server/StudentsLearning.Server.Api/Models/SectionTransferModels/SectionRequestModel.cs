namespace StudentsLearning.Server.Api.Models.SectionTransferModels
{
    using System.ComponentModel.DataAnnotations;

    public class SectionRequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}