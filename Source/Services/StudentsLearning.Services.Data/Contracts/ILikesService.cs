namespace StudentsLearning.Services.Data.Contracts
{
    using System.Linq;
    using StudentsLearning.Data.Models;

    public interface ILikesService
    {
        IQueryable<Like> AllLikesForComment(int commentId);

        void LikeComment(int commentId, string username);

        void DislikeComment(int commentId, string username);

        bool CommentIsLikedByUser(int commentId, string username);

        bool CommentIsDislikedByUser(int commentId, string userId);
    }
}
