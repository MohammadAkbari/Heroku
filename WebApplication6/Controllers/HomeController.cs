using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Connect()
        {
            var res = _blogContext.Database.CanConnect();

            return Json(res);
        }

        public IActionResult ResetDataBase()
        {
            try
            {
                var blogs = _blogContext.Blogs.ToList();

                _blogContext.RemoveRange(blogs);
                _blogContext.SaveChanges();

                return Ok("Success");
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    ex.Message,
                    InnerMessage = ex.InnerException?.Message
                });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
