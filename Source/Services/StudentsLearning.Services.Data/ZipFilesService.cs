namespace StudentsLearning.Services.Data
{
    #region

    using System.Linq;

    using StudentsLearning.Data.Models;
    using StudentsLearning.Data.Repositories;
    using StudentsLearning.Services.Data.Contracts;

    #endregion

    public class ZipFilesService : IZipFilesService
    {
        private readonly IRepository<ZipFile> zipfiles;

        public ZipFilesService(IRepository<ZipFile> zipfilesRepo)
        {
            this.zipfiles = zipfilesRepo;
        }

        public void Add(ZipFile file)
        {
            this.zipfiles.Add(file);
            this.zipfiles.SaveChanges();
        }

        public IQueryable<ZipFile> GetById(int id)
        {
            return this.zipfiles.All().Where(x => x.Id == id);
        }

        public void Update(ZipFile file)
        {
            this.zipfiles.Update(file);
            this.zipfiles.SaveChanges();
        }

        public void Delete(ZipFile zipFile)
        {
            this.zipfiles.Delete(zipFile);
            this.zipfiles.SaveChanges();
        }
    }
}