namespace StudentsLearning.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    using StudentsLearning.Data.Models;

    public interface ITopicsServices
    {
        IQueryable<Topic> All(int sectionId, int page, int pageSize);

        IQueryable<Topic> All(string contributorId);

        IQueryable<Topic> GetById(int id);

        IQueryable<Topic> GetByTitle(string title);

        void Add(Topic topic, ICollection<ZipFile> files, ICollection<Example> examples);

        //void Update(Topic topic, ZipFile newfile, ICollection<Example> newExamples);
        void Update(Topic topic);
    }
}
