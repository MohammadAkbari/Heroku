using System.Collections.Generic;

namespace WebApplication6.Data
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class CreateBlogVm
    {
        public string Name { get; set; }
    }
}
