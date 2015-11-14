namespace StudentsLearning.Data.Models
{
    // TODO: Discuss with the team where to store the zip files.
    public class ZipFile
    {
        public int Id { get; set; }

        public string OriginalName { get; set; }

        public string DbName { get; set; }

        public string Path { get; set; }

        //public string FileExtension { get; set; }

        public int TopicId { get; set; }

        public virtual Topic Topic { get; set; }

        // public byte[] Content { get; set; }
    }
}
