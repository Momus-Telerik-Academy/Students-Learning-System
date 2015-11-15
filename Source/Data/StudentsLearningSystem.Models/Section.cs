namespace StudentsLearning.Data.Models
{
    #region

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using StudentsLearning.Common;

    #endregion

    public class Section
    {
        private ICollection<Topic> topics;

        public Section()
        {
            this.topics = new HashSet<Topic>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinStringLength)]
        [MaxLength(ValidationConstants.MaxTitleLength)]
        public string Name { get; set; }

        [MaxLength(ValidationConstants.MaxDescriptionLength)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Topic> Topics
        {
            get
            {
                return this.topics;
            }

            set
            {
                this.topics = value;
            }
        }
    }
}