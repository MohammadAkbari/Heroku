using System;

namespace Data.Entities
{
    public class Post
    {
        public Post()
        {
            CreatedOn = DateTime.Now;
        }

        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Number { get; set; }
        public DateTime CreatedOn { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
