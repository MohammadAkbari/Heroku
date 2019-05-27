﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace WebApplication6.Data
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    public class AddPostVm
    {
        public AddPostVm()
        {
            CreatedOn = DateTime.Now;
        }

        public string Content { get; set; }

        public int BlogId { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<SelectListItem> BlogIdNames { get; set; }
    }
}
