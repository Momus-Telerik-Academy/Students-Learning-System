namespace StudentsLearning.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using StudentsLearning.Common;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinStringLength)]
        public string UserId { get; set; }

        public virtual CustomUser User { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinStringLength)]
        [MaxLength(ValidationConstants.MaxContentLength)]
        public string Content { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public int TopicId { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
