namespace StudentsLearning.Services.Data.Tests.TestObjects
{
    #region

    using System;

    using StudentsLearning.Data.Models;

    #endregion

    public static class TestObjectFactory
    {
        public static InMemoryRepository<User> GetUsersRepository(int numberOfUsers = 25)
        {
            var repo = new InMemoryRepository<User>();

            for (var i = 0; i < numberOfUsers; i++)
            {
                var date = new DateTime(2015, 11, 5, 23, 47, 12);
                date.AddDays(i);

                repo.Add(
                    new User
                        {
                            UserName = "Test User " + i, 
                            Email = "Test Email " + i, 
                            PasswordHash = Guid.NewGuid().ToString()
                        });
            }

            return repo;
        }

        public static InMemoryRepository<Category> GetCategoriesRepository(int numberOfCategories = 10)
        {
            var repo = new InMemoryRepository<Category>();

            for (var i = 0; i < numberOfCategories; i++)
            {
                var category = new Category { Name = "TestCategory" + i };

                repo.Add(category);
            }

            return repo;
        }
    }
}