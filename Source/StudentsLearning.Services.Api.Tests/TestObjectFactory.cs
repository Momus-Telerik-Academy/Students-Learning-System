using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using StudentsLearning.Data.Models;
using StudentsLearning.Services.Data.Contracts;

namespace StudentsLearning.Services.Api.Tests
{
    public class TestObjectFactory
    {
        private static IQueryable<Category> categories = new List<Category>
        {
            new Category()
            {
                Name="TestCategory"
            },
            new Category()
            {
                Name="TestCategory2"
            }
        }.AsQueryable();

        public static ICategoriesService GetCategoriesService()
        {
            var mockedCategoriesService = new Mock<ICategoriesService>();

            mockedCategoriesService.Setup(s => s.All()).Returns(categories);

            mockedCategoriesService.Setup(s => s.Add(It.IsAny<string>()));//returns

            mockedCategoriesService.Setup(s => s.GetById(It.IsAny<int>())).Returns(categories.First());

            mockedCategoriesService.Setup(s => s.GetId(It.IsAny<string>())).Returns(categories.First().Id);

            mockedCategoriesService.Setup(s => s.Update(It.IsAny<Category>()));

            return mockedCategoriesService.Object;
        }
    }
}
