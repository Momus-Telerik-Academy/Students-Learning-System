namespace StudentsLearning.Data.Models
{
    #region

    using System.ComponentModel.DataAnnotations;

    using StudentsLearning.Common;

    #endregion

    public class Example
    {
        public int Id { get; set; }

        public string Description { get; set; }

        [MaxLength(ValidationConstants.MaxTitleLength)]
        public string Content { get; set; }

        public int TopicId { get; set; }

        public virtual Topic Topic { get; set; }
    }
}