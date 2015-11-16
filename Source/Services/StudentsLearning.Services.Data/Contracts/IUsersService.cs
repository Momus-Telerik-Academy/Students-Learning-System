namespace StudentsLearning.Services.Data.Contracts
{
    #region

    using System.Linq;

    using StudentsLearning.Data.Models;

    #endregion

    public interface IUsersService
    {
        IQueryable<User> GetUserById(string id);
    }
}