namespace StudentsLearning.Services.Data.Contracts
{
    using StudentsLearning.Data.Models;
    using System.Linq;

    public interface ICommentService
    {
        IQueryable<Comment> All();

        IQueryable<Comment> GetById(int id);

        IQueryable<Comment> GetId(string commentContent);

        void Add(Comment comment);

        void Update(Comment comment);
    }
}
