namespace StudentsLearning.Server.Api.Models.AccountBindingModels
{
    #region

    using System.ComponentModel.DataAnnotations;

    #endregion

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}