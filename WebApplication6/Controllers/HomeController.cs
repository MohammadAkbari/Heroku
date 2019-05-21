using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;
using WebApplication6.Models;

namespace WebApplication6.Controllers
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
            return View();
        }

        public IActionResult Add(string name)
        {
            try
            {
                var blog = new Blog
                {
                    Url = "akbari.id.ir",
                    Name = name,
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
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    ex.Message,
                    InnerMessage = ex.InnerException?.Message
                });
            }

            return Ok();
        }

        public IActionResult GetBlogs()
        {
            var res = _blogContext.Blogs.Select(e=>new { e.BlogId, e.Name, e.Url}).ToList();

            return Json(res);
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
