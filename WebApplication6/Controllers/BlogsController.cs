using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;

namespace WebApplication6.Controllers
{
    public class BlogsController : Controller
    {
        private readonly BlogContext _blogContext;

        public BlogsController(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public IActionResult Index()
        {
            var blogs = _blogContext.Blogs.ToList();
            return View(blogs);
        }

        public IActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBlog(CreateBlogVm vm)
        {
            try
            {
                var blog = new Blog
                {
                    Name = vm.Name
                };

                _blogContext.Blogs.Add(blog);

                _blogContext.SaveChanges();

                return RedirectToAction(nameof(Blog), new { id = blog.BlogId });
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

        public IActionResult AddPost()
        {
            var blogs = _blogContext.Blogs.ToList();

            var vm = new AddPostVm
            {
                BlogIdNames = blogs.Select(e => new SelectListItem
                {
                    Text = e.Name,
                    Value = e.BlogId.ToString()
                }).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddPost(AddPostVm vm)
        {
            try
            {
                var post = new Post
                {
                    Content = vm.Content,
                    BlogId = vm.BlogId
                };

                _blogContext.Posts.Add(post);

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

            return RedirectToAction(nameof(Blog), new { id = vm.BlogId });
        }

        public IActionResult Blog(int id)
        {
            var blog = _blogContext.Blogs.Where(e=>e.BlogId == id)
                .Include(e=>e.Posts)
                .FirstOrDefault();

            return View(blog);
        }
    }
}