namespace StudentsLearning.Services.Data.Contracts
{
    using System.Linq;
    using StudentsLearning.Data.Models;

    public interface ILikesService
    {
        IQueryable<Like> AllLikesForComment(int commentId);

        void ChangeLikeStatus(int commentId, string username, bool isPositive);
        
        bool CommentIsLikesByUser(int commentId, string username, bool isPositive);
    }
}
