namespace StudentsLearning.Services.Data.Contracts
{
    #region

    using StudentsLearning.Data.Models;

    #endregion

    public interface IUsersService
    {
        User GetUserById(string id);
    }
}