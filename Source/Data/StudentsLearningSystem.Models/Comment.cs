namespace StudentsLearning.Data.Models
{
    #region

    using System.ComponentModel.DataAnnotations;

    using StudentsLearning.Common;
    using System.Collections.Generic;

    #endregion

    public class Comment
    {
        private ICollection<Like> likes;

        public Comment()
        {
            this.likes = new HashSet<Like>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinStringLength)]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinStringLength)]
        [MaxLength(ValidationConstants.MaxContentLength)]
        public string Content { get; set; }
        
        public int TopicId { get; set; }

        public virtual Topic Topic { get; set; }

        public virtual ICollection<Like> Likes
        {
            get
            {
                return this.likes;
            }

            set
            {
                this.likes = value;
            }
        }
    }
}