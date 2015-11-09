namespace StudentsLearning.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class Category
    {
        private ICollection<Section> sections;

        public Category()
        {
            this.sections = new HashSet<Section>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinStringLength)]
        [MaxLength(ValidationConstants.MaxTitleLength)]
        public string Name { get; set; }

        public virtual ICollection<Section> Sections
        {
            get { return this.sections; }
            set { this.sections = value; }
        }
    }
}
