namespace StudentsLearning.Services.Data
{
    using System;
    using System.Linq;
    using StudentsLearning.Data.Models;
    using StudentsLearning.Services.Data.Contracts;
    using StudentsLearning.Data.Repositories;

    public class SectionService : ISectionService
    {

        private IRepository<Section> sections;

        public SectionService(IRepository<Section> sections)
        {
            this.sections = sections;
        }

        public void Add(Section section)
        {
            this.sections.Add(section);
            this.sections.SaveChanges();
        }

        public IQueryable<Section> All()
        {
            return this.sections.All();
        }

        public Section GetById(int id)
        {
            return this.All()
                        .Where(x => x.Id == id)
                        .FirstOrDefault();
        }

        public IQueryable<Section> GetByName(string name)
        {
            return this.All()
                       .Where(x => x.Name == name);
        }

        public int? GetId(string name)
        {
            return this.All()
                       .Where(x => x.Name == name)
                       .Select(c => c.Id)
                       .FirstOrDefault();
        }

        public void Update(Section section)
        {
            this.sections.Update(section);
            this.sections.SaveChanges();
        }
    }
}
