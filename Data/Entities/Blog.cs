using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Blog
    {
        public Blog()
        {
            CreatedOn = DateTime.Now;
        }

        public int BlogId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

        public List<Post> Posts { get; set; }
        public DateTime CreatedOn { get; private set; }
    }
}
