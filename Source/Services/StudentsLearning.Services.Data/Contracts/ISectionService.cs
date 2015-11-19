namespace StudentsLearning.Services.Data.Contracts
{
    #region

    using System.Linq;

    using StudentsLearning.Data.Models;

    #endregion

    public interface ISectionService
    {
        IQueryable<Section> All();

        IQueryable<Section> GetById(int id);

        IQueryable<Section> GetByName(string name);

        void Add(Section section);

        void Update(Section section);

        void Delete(int id);
    }
}