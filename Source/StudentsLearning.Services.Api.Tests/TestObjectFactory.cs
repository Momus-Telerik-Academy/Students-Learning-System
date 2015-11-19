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
        private static readonly IQueryable<Category> Categories =
            new List<Category> { new Category { Id=1, Name = "TestCategory" }, new Category { Id = 2, Name = "TestCategory2" } }
                .AsQueryable();

        private static readonly IQueryable<Section> Sections = new List<Section>
        {
            new Section()
            {
                Id = 1,
                Name = "Lorem ipsum",
                Description = "Lorem Ipsum dor..."
            },
            new Section()
            {
                Id = 2,
                Name = "To be or not to be",
                Description = "Lorem Ipsum dor..."
            }
        }.AsQueryable();

        private static readonly IQueryable<Section> SingleSectionAsQueriable = new List<Section>
        {
            new Section()
            {
                Id = 1,
                Name = "Lorem ipsum",
                Description = "Lorem Ipsum dor..."
            }
        }.AsQueryable();

        private static readonly IQueryable<Topic> SingleTopicAsQueriable = new List<Topic>
        {
            new Topic()
            {
                Id = 1,
                Content = "Lorem Ipsum dor...",
                Title = "23fvewrdf"
            }
        }.AsQueryable();

        private static readonly IQueryable<Topic> Topics = new List<Topic>
        {
            new Topic()
            {
                Id = 1,
                Content = "Lorem Ipsum dor...",
                Title = "23fvewrdf"
            },
            new Topic()
            {
                Id = 2,
                Content = "To be or not to be",
                Title = "nevrujbnfdrf fed"
            }
        }.AsQueryable();

        public static ICategoriesService GetCategoriesService()
        {
            var mockedCategoriesService = new Mock<ICategoriesService>();

            mockedCategoriesService.Setup(s => s.All()).Returns(Categories);
            mockedCategoriesService.Setup(s => s.Add(It.IsAny<string>())); // returns
            mockedCategoriesService.Setup(s => s.GetById(It.IsAny<int>())).Returns(Categories.First());
            mockedCategoriesService.Setup(s => s.GetId(It.IsAny<string>())).Returns(Categories.First().Id);
            mockedCategoriesService.Setup(s => s.Update(It.IsAny<Category>()));

            return mockedCategoriesService.Object;
        }

        public static ICategoriesService GetCategoriesServiceNotFound()
        {
            var mockedCategoriesService = new Mock<ICategoriesService>();

            mockedCategoriesService.Setup(s => s.All()).Returns(null as IQueryable<Category>);
            mockedCategoriesService.Setup(s => s.GetById(It.IsAny<int>())).Returns(null as Category);
            mockedCategoriesService.Setup(s => s.GetId(It.IsAny<string>())).Returns(null as int?);

            return mockedCategoriesService.Object;
        }

        public static ISectionService GetSectionService()
        {
            var mockedSectionsService = new Mock<ISectionService>();

            mockedSectionsService.Setup(s => s.GetById(It.IsAny<int>())).Returns(SingleSectionAsQueriable);
            mockedSectionsService.Setup(s => s.Add(It.IsAny<Section>()));
            mockedSectionsService.Setup(s => s.All()).Returns(Sections);
            mockedSectionsService.Setup(s => s.GetByName(It.IsAny<string>())).Returns(SingleSectionAsQueriable);
            mockedSectionsService.Setup(s => s.Update(It.IsAny<Section>()));

            return mockedSectionsService.Object;
        }

        public static ISectionService GetSectionServiceNotFoundMock()
        {
            var mockedSectionsService = new Mock<ISectionService>();

            mockedSectionsService.Setup(s => s.GetById(It.IsAny<int>())).Returns(null as IQueryable<Section>);
            mockedSectionsService.Setup(s => s.GetByName(It.IsAny<string>())).Returns(null as IQueryable<Section>);

            return mockedSectionsService.Object;
        }

        public static ITopicsServices GetTopicsService()
        {
            var mockedTopicService = new Mock<ITopicsServices>();

            mockedTopicService.Setup(s => s.GetById(It.IsAny<int>())).Returns(SingleTopicAsQueriable);
            mockedTopicService.Setup(s => s.Add(It.IsAny<Topic>(), It.IsAny<User>()));
            mockedTopicService.Setup(s => s.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Topics);
            mockedTopicService.Setup(s => s.Update(It.IsAny<Topic>()));
            mockedTopicService.Setup(s => s.GetByTitle(It.IsAny<string>())).Returns(SingleTopicAsQueriable);
            return mockedTopicService.Object;
        }
    }
}