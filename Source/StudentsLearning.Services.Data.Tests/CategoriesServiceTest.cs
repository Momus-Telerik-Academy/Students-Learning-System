namespace StudentsLearning.Services.Data.Tests
{
    using NUnit.Framework;
    using StudentsLearning.Services;
    using StudentsLearning.Data.Models;
    using StudentsLearning.Models;
    using StudentsLearning.Services.Data.Contracts;
    using StudentsLearning.Services.Data.Tests.TestObjects;

    [TestFixture]
    public class CategoriesServiceTest
    {
        //private InMemoryRepository<User> userRepo;
        private InMemoryRepository<Category> categoriesRepo;
        private ICategoriesService categoriesService;

        [TestFixtureSetUp]
        public void Init()
        {
            //this.userRepo = TestObjectFactory.GetUsersRepository();
            this.categoriesRepo = TestObjectFactory.GetCategoriesRepository();

            this.categoriesService=new CategoriesService(categoriesRepo);
        }

        [Test]
        public void CategoriesServiceAddShouldInvokeSaveChanges()
        {
            this.categoriesService.Add("Test category");

            Assert.AreEqual(1, this.categoriesRepo.NumberOfSaves);
        }
    }
}
