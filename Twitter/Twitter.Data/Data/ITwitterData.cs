namespace Twitter.Data.Data
{
    using Twitter.Data.Repositories;
    using Twitter.Models;

    public interface ITwitterData
    {
        IRepository<ApplicationUser> User { get; }

        IRepository<Message> Message { get; }

        IRepository<Notification> Notification { get; }

        IRepository<Retweet> Retweet { get; }

        IRepository<Tweet> Tweet { get; } 

        int SaveChanges();
    }
}
