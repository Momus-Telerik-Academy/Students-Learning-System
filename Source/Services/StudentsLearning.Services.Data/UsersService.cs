namespace StudentsLearning.Services.Data
{
    using StudentsLearning.Data.Models;
    using StudentsLearning.Data.Repositories;
    using StudentsLearning.Services.Data.Contracts;

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public User GetUserById(string id)
        {
            return this.users.GetById(id);
        }
    }
}
