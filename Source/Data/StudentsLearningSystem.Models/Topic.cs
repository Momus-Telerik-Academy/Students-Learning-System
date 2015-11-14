namespace StudentsLearning.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Topic
    {
        private ICollection<Example> examples;
        private ICollection<Comment> comments;
        private ICollection<ZipFile> zipFiles;
        private ICollection<User> contributors;

        public Topic()
        {
            this.examples = new HashSet<Example>();
            this.comments = new HashSet<Comment>();
            this.zipFiles = new HashSet<ZipFile>();
            this.contributors = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinStringLength)]
        [MaxLength(ValidationConstants.MaxTitleLength)]
        public string Title { get; set; }

        [MaxLength(ValidationConstants.MaxContentLength)]
        public string Content { get; set; }

        public string VideoId { get; set; }

        public int SectionId { get; set; }

        public virtual Section Section { get; set; }

        public virtual ICollection<Example> Examples
        {
            get { return this.examples; }
            set { this.examples = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<ZipFile> ZipFiles
        {
            get { return this.zipFiles; }
            set { this.zipFiles = value; }
        }

        public virtual ICollection<User> Contributors
        {
            get { return this.contributors; }
            set { this.contributors = value; }
        }

    }
}
