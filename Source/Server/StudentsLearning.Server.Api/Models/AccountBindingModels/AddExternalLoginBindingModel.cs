namespace StudentsLearning.Server.Api.Models.AccountBindingModels
{
    #region

    using System.ComponentModel.DataAnnotations;

    #endregion

    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }
}