namespace StudentsLearning.Services.Data
{
    #region

    using System.Linq;

    using StudentsLearning.Data.Models;
    using StudentsLearning.Data.Repositories;
    using StudentsLearning.Services.Data.Contracts;

    #endregion

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetUserById(string id)
        {
            return this.users.All().Where(x=>x.Id==id);
        }
    }
}