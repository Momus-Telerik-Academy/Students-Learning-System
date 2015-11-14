namespace StudentsLearning.Services.Data.Contracts
{
    using StudentsLearning.Data.Models;

    public interface IUsersService
    {
        User GetUserById(string id);
    }
}
