namespace StudentsLearning.Services.Data.Contracts
{
    #region

    using System.Linq;

    using StudentsLearning.Data.Models;

    #endregion

    public interface IZipFilesService
    {
        IQueryable<ZipFile> GetById(int id);

        void Add(ZipFile file);

        void Update(ZipFile file);

        void Delete(ZipFile file);
    }
}