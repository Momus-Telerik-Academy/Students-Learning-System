namespace StudentsLearning.Services.Api.Tests
{
    #region

    using System.Collections.Generic;
    using System.Linq;

    using Moq;

    using StudentsLearning.Data.Models;
    using StudentsLearning.Services.Data.Contracts;

    #endregion

    public class TestObjectFactory
    {
        private static readonly IQueryable<Category> categories =
            new List<Category> { new Category { Id=1, Name = "TestCategory" }, new Category { Id = 2, Name = "TestCategory2" } }
                .AsQueryable();

        public static ICategoriesService GetCategoriesService()
        {
            var mockedCategoriesService = new Mock<ICategoriesService>();

            mockedCategoriesService.Setup(s => s.All()).Returns(categories);

            mockedCategoriesService.Setup(s => s.Add(It.IsAny<string>())); // returns

            mockedCategoriesService.Setup(s => s.GetById(It.IsAny<int>())).Returns(categories.First());

            mockedCategoriesService.Setup(s => s.GetId(It.IsAny<string>())).Returns(categories.First().Id);

            mockedCategoriesService.Setup(s => s.Update(It.IsAny<Category>()));

            return mockedCategoriesService.Object;
        }
    }
}