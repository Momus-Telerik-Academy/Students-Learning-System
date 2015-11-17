namespace StudentsLearning.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Like
    {
        [Key]
        public int Id { get; set; }

        public bool IsPositive { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
