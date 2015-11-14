namespace StudentsLearning.Data.Models
{
    using System.Collections.Generic;

    using StudentsLearning.Models;

    public class CustomUser : User
    {
        private ICollection<Topic> topicsContributions;

        public CustomUser()
        {
            this.topicsContributions = new HashSet<Topic>();
        }

        public virtual ICollection<Topic> TopicsContibutions
        {
            get { return this.topicsContributions; }
            set { this.topicsContributions = value; }
        }
    }
}
