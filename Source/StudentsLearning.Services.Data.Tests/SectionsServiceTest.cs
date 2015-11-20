using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StudentsLearning.Data.Models;
using StudentsLearning.Services.Data.Contracts;
using StudentsLearning.Services.Data.Tests.TestObjects;

namespace StudentsLearning.Services.Data.Tests
{
    [TestFixture]
    public class SectionsServiceTest
    {
        private InMemoryRepository<Section> sectionsRepo;

        private ISectionService sectionsService;

        [TestFixtureSetUp]
        public void Init()
        {
            // this.userRepo = TestObjectFactory.GetUsersRepository();
            this.sectionsRepo = TestObjectFactory.GetSectionsRepository();

            this.sectionsService = new SectionService(this.sectionsRepo);
        }

        [Test]
        public void SectionsServicesAddShouldInvokeSaveChanges()
        {
            var section = new Section()
            {
                Description = "A descriptive description of the descriptor.",
                Name = "name"
            };

            this.sectionsService.Add(section);

            Assert.AreEqual(1, this.sectionsRepo.NumberOfSaves);
        }

        [Test]
        public void SectionsServicesGetByIdShouldReturnsectionIfIdExists()
        {
            var section = this.sectionsRepo.All().First();

            var result = this.sectionsService.GetById(section.Id).FirstOrDefault();

            Assert.AreSame(result.GetType(), typeof(Section), "The returned object is not of type section");
            Assert.AreNotSame(result, null, "The returned section is null");
        }

        [Test]
        public void SectionsServicesGetIdShouldReturnSectionIfExists()
        {
            var section = this.sectionsRepo.All().First();

            var id = this.sectionsService.GetByName(section.Name);

            Assert.AreNotEqual(id, null);
        }

        [Test]
        public void SectionsServicesUpdateShouldChangeThesection()
        {
            var section = this.sectionsRepo.All().First();
            var name = section.Name;

            section.Name = name + "Changed";
            this.sectionsService.Update(section);

            // TODO: if updated multiple times in repo
            var updatedsection = this.sectionsRepo.UpdatedEntities.LastOrDefault();

            Assert.AreNotEqual(updatedsection, null);
            Assert.AreNotEqual(name, updatedsection.Name);
        }
    }
}
