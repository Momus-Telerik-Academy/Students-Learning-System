namespace StudentsLearning.Server.Api.Models.CommentTransferModels
{
    public class CommentRequestModel
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public int? Likes { get; set; }

        public int? Dislikes { get; set; }

        public int TopicId { get; set; }
    }
}