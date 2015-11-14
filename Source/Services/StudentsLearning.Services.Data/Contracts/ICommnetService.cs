namespace StudentsLearning.Services.Data.Contracts
{
    #region

    using System.Linq;

    using StudentsLearning.Data.Models;

    #endregion

    public interface ICommentService
    {
        IQueryable<Comment> All();

        IQueryable<Comment> GetById(int id);

        IQueryable<Comment> GetId(string commentContent);

        void Add(Comment comment);

        void Update(Comment comment);
    }
}