namespace StudentsLearning.Data.Models
{
    #region

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using StudentsLearning.Common;

    #endregion

    public class Category
    {
        private ICollection<Section> sections;

        public Category()
        {
            this.sections = new HashSet<Section>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.MinStringLength)]
        [MaxLength(ValidationConstants.MaxTitleLength)]
        public string Name { get; set; }

        public virtual ICollection<Section> Sections
        {
            get
            {
                return this.sections;
            }

            set
            {
                this.sections = value;
            }
        }
    }
}