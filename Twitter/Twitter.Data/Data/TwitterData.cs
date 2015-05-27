namespace Twitter.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Twitter.Data.Repositories;
    using Twitter.Models;

    public class TwitterData : ITwitterData
    {
        public IApplicationDbContext context;

        private IDictionary<Type, object> repositories;

        public TwitterData(IApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> User
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public IRepository<Message> Message
        {
            get { return this.GetRepository<Message>(); }
        }

        public IRepository<Notification> Notification
        {
            get { return this.GetRepository<Notification>(); }
        }

        public IRepository<Retweet> Retweet
        {
            get { return this.GetRepository<Retweet>(); }
        }

        public IRepository<Tweet> Tweet
        {
            get { return this.GetRepository<Tweet>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);

                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }

    }
}
