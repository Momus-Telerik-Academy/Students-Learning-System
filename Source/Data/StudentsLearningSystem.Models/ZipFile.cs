namespace StudentsLearning.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    // TODO: Discuss with the team where to store the zip files.
    public class ZipFile
    {
        [Key, ForeignKey("Topic")]
        public int Id { get; set; }

        public string OriginalName { get; set; }

        public string DbName { get; set; }

        public string Path { get; set; }

        //public string FileExtension { get; set; }

        public virtual Topic Topic { get; set; }

        // public byte[] Content { get; set; }
    }
}
