using CalisthenicsSystem.Data;

namespace CalisthenicsSystem.Services
{
    public class Service
    {
        public Service()
        {
            this.Context = new CalisthenicsSystemContext();
        }

        protected CalisthenicsSystemContext Context { get; }
    }
}
