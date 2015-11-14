using System;
using System.Linq;

namespace StudentsLearning.Services.Data.Tests
{
    using System.Linq;
    using NUnit.Framework;
    using StudentsLearning.Services;
    using StudentsLearning.Data.Models;
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

            this.categoriesService = new CategoriesService(categoriesRepo);
        }

        [Test]
        public void CategoriesServicesAddShouldInvokeSaveChanges()
        {
            this.categoriesService.Add("Test category");

            Assert.AreEqual(1, this.categoriesRepo.NumberOfSaves);
        }

        [Test]
        public void CategoriesServicesGetIdShouldReturnIndexIfCategoryExists()
        {
            var category = categoriesRepo.All().First();

            int? id = categoriesService.GetId(category.Name);

            Assert.AreNotEqual(id, null);
        }

        [TestCase("")]
        [TestCase("    ")]
        [TestCase(null)]
        [ExpectedException(typeof (ArgumentNullException))]
        public void CategoriesServicesAddShouldThrowIfNameIsNullOrWhitespace(string name)
        {
            this.categoriesService.Add(name);
        }

        [Test]
        public void CategoriesServicesGetIdShouldReturnNullIfCategoryDoesNotExist()
        {
            var categoryName = "Bad Wolf";

            int? id = categoriesService.GetId(categoryName);

            Assert.AreEqual(id, null);
        }

        [Test]
        public void CategoriesServicesGetByIdShouldReturnCategoryIfIdExists()
        {
            var category = categoriesRepo.All().First();

            var result = categoriesService.GetById(category.Id);

            Assert.AreSame(result.GetType(), typeof(Category), "The returned object is not of type Category");
            Assert.AreSame(result, null, "The returned category is null");
        }

        [TestCase(666338500)]
        [TestCase(-3)]
        public void CategoriesServicesGetByIdShouldReturnNullIfIdDoesNotExist(int id)
        {
            var result = categoriesService.GetById(id);

            Assert.AreSame(result, null);
        }

        [Test]
        public void CategoriesServicesUpdateShouldChangeTheCategory()
        {
            var category = categoriesRepo.All().First();
            var name = category.Name;
            var id = category.Id;

            category.Name = name + "Changed";
            categoriesService.Update(category);

            // TODO: if updated nultiuple times in repo
            var updatedCategory = categoriesRepo.UpdatedEntities.LastOrDefault();

            Assert.AreNotEqual(updatedCategory, (null));
            Assert.AreNotEqual(name, updatedCategory.Name);
        }


    }
}