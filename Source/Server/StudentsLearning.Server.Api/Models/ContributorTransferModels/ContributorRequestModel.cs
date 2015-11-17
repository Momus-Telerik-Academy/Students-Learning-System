namespace StudentsLearning.Server.Api.Models.ContributorTransferModels
{
    using System.ComponentModel.DataAnnotations;

    public class ContributorRequestModel
    {
        [Required]
        public string Id { get; set; }
    }
}