using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Data;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogContext _blogContext;

        public HomeController(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public IActionResult Index()
        {
            var blog = new Blog
            {
                Url = "NiniSite.com",
                Posts = new List<Post>
                {
                    new Post
                    {
                        Content = "طبق آمار، بیماری های قلبی عروقی با بیش از 17 میلیون مرگ در سال، مهمترین عامل مرگ و میر در جهان به شمار می روند.",
                        Title = "فشار خون بالا، قاتل خاموش",
                    }
                }
            };

            _blogContext.Blogs.Add(blog);
            _blogContext.SaveChanges();

            var res = _blogContext.Blogs.Include(e => e.Posts);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
