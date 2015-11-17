namespace StudentsLearning.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using StudentsLearning.Data.Models;
    using StudentsLearning.Data.Repositories;
    using StudentsLearning.Services.Data.Contracts;

    public class TopicsServices : ITopicsServices
    {
        private readonly IRepository<User> contributors;

        private readonly IRepository<Topic> topics;

        private readonly IRepository<ZipFile> zipFiles;

        public TopicsServices(
            IRepository<Topic> topicsRepo,
            IRepository<ZipFile> zipFilesRepo,
            IRepository<User> contributors)
        {
            this.topics = topicsRepo;
            this.zipFiles = zipFilesRepo;
            this.contributors = contributors;
        }

        public void Add(Topic topic,  ICollection<Example> examples, User contributor)
        {
            foreach (var example in examples)
            {
                topic.Examples.Add(example);
            }
                       
            topic.Contributors.Add(contributor);
            this.topics.Add(topic);
            this.topics.SaveChanges();
        }

        public IQueryable<Topic> All(int sectionId, int page = 1, int pageSize = 10)
        {
            return
                this.topics.All()
                    .Where(x => x.Section.Id == sectionId)
                    .OrderByDescending(pr => pr.Title)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
        }

        public IQueryable<Topic> All(string contributorId)
        {
            return this.topics.All().Where(x => x.Contributors.Any(c => c.Id == contributorId));
        }

        public IQueryable<Topic> GetById(int id)
        {
            return this.topics.All().Where(x => x.Id == id);
        }

        public IQueryable<Topic> GetByTitle(string title)
        {
            return this.topics.All().Where(x => x.Title == title);
        }

        // TODO: Why public void Update(Topic topic, ZipFile newfile, ICollection<Example> newExamples) ??
        public void Update(Topic topic)
        {
            // topic
            // .Examples
            // .ToList()
            // .ForEach(i => topic.Examples.Remove(i));
            // foreach (var example in newExamples)
            // {
            // topic.Examples.Add(example);
            // }
            this.topics.Update(topic);

            this.topics.SaveChanges();
        }

        // }
        // return id;
        // .FirstOrDefault();
        // .Select(i => i.Id)
        // .Where(x => x.Id == file.Id)
        // .All()
        // var id = this.zipFiles
        // {

        // private int GetZipFileId(Topic topic, ZipFile file)
    }
}