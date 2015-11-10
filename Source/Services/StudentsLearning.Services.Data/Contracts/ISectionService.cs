namespace StudentsLearning.Services.Data.Contracts
{
    using StudentsLearning.Data.Models;
    using System.Linq;

    public interface ISectionService
    {
        IQueryable<Section> All();

        IQueryable<Section> GetById(int id);
        
        IQueryable<Section> GetByName(string name);

        void Add(Section section);

        void Update(Section section);
    }
}
