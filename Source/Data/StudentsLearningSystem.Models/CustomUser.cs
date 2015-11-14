namespace StudentsLearning.Data.Models
{
    using System.Collections.Generic;

    using StudentsLearning.Models;

    public class CustomUser : User
    {
        private ICollection<Topic> topicsContributions;
        private ICollection<Comment> comments;

        public CustomUser()
        {
            this.topicsContributions = new HashSet<Topic>();
            this.comments = new HashSet<Comment>();
        }

        public virtual ICollection<Topic> TopicsContibutions
        {
            get { return this.topicsContributions; }
            set { this.topicsContributions = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
