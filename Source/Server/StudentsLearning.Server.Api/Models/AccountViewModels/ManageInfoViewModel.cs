namespace StudentsLearning.Server.Api.Models.AccountViewModels
{
    #region

    using System.Collections.Generic;

    #endregion

    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }
}