using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace FitnessHardSoft.Controllers
{
    
    public class HomeController : Controller
    {

        BlogDbContext blogDbContext = new BlogDbContext();
        public class news
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public List<string> Author { get; set; }
            public int AuthorID { get; set; }
            public string PicLink { get; set; }
            public int ID { get; set; }
        }
        public class trainer
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string Desc { get; set; }
            public string PicLink { get; set; }
        }
        public class wholeInfo
        {
            public List<news> News{get;set;}
            public List<trainer> Trainers{get;set;}
}

        public ActionResult Trainers()
        {
            List<trainer> trainers = blogDbContext.Users.Where(user => user.IsTrainer == 1).Select(user => new trainer { Name = user.FirstName, LastName = user.LastName, Desc = user.Description, PicLink = user.PictureLink }).ToList();
            return View(trainers);
        }
        public ActionResult News()
        {
            List<news> WholeNews = blogDbContext
               .News
               .Select(news =>
               new news
               {
                   Title = news.Title,
                   Content = news.ContentOfArticle,
                   ID = news.ID,
                   AuthorID = news.AuthorOfNewsID,
                   PicLink = news.PicLink
               })
               .OrderByDescending(g => g.ID)
               .ToList();
            foreach (var item in WholeNews)
            {
                item.Author = blogDbContext.Users.Where(user => user.ID == item.AuthorID).Select(user => user.FirstName).Take(1).ToList();
            }
            return View(WholeNews);
        }

        public ActionResult Index()
        {
            wholeInfo wholeInfo = new wholeInfo();
            wholeInfo.Trainers = blogDbContext.Users.Where(user => user.IsTrainer == 1).Select(user => new trainer{ Name = user.FirstName, LastName = user.LastName, Desc = user.Description, PicLink = user.PictureLink}).Take(4).ToList();
            wholeInfo.News = blogDbContext
                .News
                .Select(news => 
                new news {
                    Title = news.Title,
                    Content = news.ContentOfArticle,
                    ID = news.ID,
                    AuthorID = news.AuthorOfNewsID,
                    PicLink = news.PicLink
                })
                .OrderByDescending(g=>g.ID)
                .Take(6)
                .ToList();
            foreach (var item in wholeInfo.News)
            {
                item.Author = blogDbContext.Users.Where(user => user.ID == item.AuthorID).Select(user=>user.FirstName).Take(1).ToList();
            }
            return View(wholeInfo);
        }
    }
    
}