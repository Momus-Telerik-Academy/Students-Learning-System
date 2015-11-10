namespace StudentsLearning.Services.Data.Contracts
{
    using StudentsLearning.Data.Models;
    using System.Linq;

    public interface IZipFilesService
    {
        IQueryable<ZipFile> GetById(int id);

        void Add(ZipFile file);

        void Update(ZipFile file);
    }
}
