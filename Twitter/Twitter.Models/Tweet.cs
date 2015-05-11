namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tweet
    {
        public Tweet()
        {
            this.Tweets = new HashSet<Tweet>();
            this.Replies = new HashSet<Tweet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(140), MinLength(1)]
        public string Text { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public string Url { get; set; }

        [InverseProperty("Replies")]
        public virtual ICollection<Tweet> Tweets { get; set; }

        public virtual ICollection<Tweet> Replies { get; set; }
    }
}
