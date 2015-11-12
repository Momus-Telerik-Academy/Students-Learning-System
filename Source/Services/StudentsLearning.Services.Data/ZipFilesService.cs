namespace StudentsLearning.Services.Data
{
    using StudentsLearning.Services.Data.Contracts;
    using StudentsLearning.Data.Models;
    using StudentsLearning.Data.Repositories;
    using System.Linq;

    public class ZipFilesService : IZipFilesService
    {
        private readonly IRepository<ZipFile> zipfiles;

        public ZipFilesService(IRepository<ZipFile> zipfilesRepo)
        {
            this.zipfiles = zipfilesRepo;
        }

        public void Add(ZipFile file)
        {
            zipfiles.Add(file);
            zipfiles.SaveChanges();
        }

        public IQueryable<ZipFile> GetById(int id)
        {
            return this.zipfiles
                        .All()
                        .Where(x => x.TopicId == id);
        }

        public void Update(ZipFile file)
        {
            this.zipfiles
                .Update(file);
            this.zipfiles
                .SaveChanges();
        }
    }
}
