using StudentsLearning.Server.Api.Models.SectionTransferModels;

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

        private static readonly IQueryable<Section> Sections = new List<Section>
        {
            new Section()
            {
                Name = "Test section"
            }
        }.AsQueryable();

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

        public static ISectionService GetSectionService()
        {
            var mockedSectionsService = new Mock<ISectionService>();
            mockedSectionsService.Setup(s => s.GetById(It.IsAny<int>())).Returns(Sections);

            return mockedSectionsService.Object;
        }
    }
}