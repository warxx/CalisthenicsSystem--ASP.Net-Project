using CalisthenicsSystem.Data.Contracts;
using CalisthenicsSystem.Models.EntityModels;

namespace CalisthenicsSystem.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CalisthenicsSystemContext context;
        private IRepository<Article> articles;
        private IRepository<Exercise> exercises;
        private IRepository<Message> messages;
        private IRepository<Note> notes;
        private IRepository<Reply> replies;
        private IRepository<Topic> topics;
        

        public IRepository<Article> Articles
             => this.articles ?? (this.articles = new Repository<Article>(this.context.Articles));

        public IRepository<Exercise> Exercises
             => this.exercises ?? (this.exercises = new Repository<Exercise>(this.context.Exercises));

        public IRepository<Message> Messages
             => this.messages ?? (this.messages = new Repository<Message>(this.context.Messages));

        public IRepository<Note> Notes
             => this.notes ?? (this.notes = new Repository<Note>(this.context.Notes));

        public IRepository<Reply> Replies
             => this.replies ?? (this.replies = new Repository<Reply>(this.context.Replies));

        public IRepository<Topic> Topics
             => this.topics ?? (this.topics = new Repository<Topic>(this.context.Topics));


        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
