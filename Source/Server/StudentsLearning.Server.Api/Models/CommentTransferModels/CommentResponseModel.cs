namespace StudentsLearning.Server.Api.Models.CommentTransferModels
{
    public class CommentResponseModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public int TopicId { get; set; }
    }
}