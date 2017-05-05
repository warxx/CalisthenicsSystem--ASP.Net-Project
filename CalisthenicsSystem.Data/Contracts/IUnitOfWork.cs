using CalisthenicsSystem.Models.EntityModels;

namespace CalisthenicsSystem.Data.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Article> Articles { get; }

        IRepository<Exercise> Exercises { get; }

        IRepository<Message> Messages { get; }

        IRepository<Note> Notes { get; }

        IRepository<Reply> Replies { get; }

        IRepository<Topic> Topics { get; }

        int SaveChanges();
    }
}
