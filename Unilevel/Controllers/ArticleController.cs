using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unilevel.Models;
using Unilevel.DTO;
using System.IO;
using System.Threading.Tasks;

namespace Unilevel.Controllers
{
    public class ArticleController : ApiController
    {
        UnilevelDbContext dbContext = new UnilevelDbContext();

        // Get all article
        [Route("api/Article")]
        [HttpGet]
        public IHttpActionResult GetAllArticle()
        {
            var listArticle = (from a in dbContext.Articles
                            select new Articles()
                            {
                                Id = a.ArticleID,
                                Title = a.Title,
                                HyperText = a.HyperText,
                                Description = a.Description,
                                CreatedAt = a.CreatedAt,
                                Creator = a.User.FullName
                            }).ToList();
            return Json(listArticle);
        }

        // Get article by id
        [Route("api/Article/{id}")]
        [HttpGet]
        public IHttpActionResult GetArticleByID(int id)
        {
            var listArticle = (from a in dbContext.Articles
                               select new Articles()
                               {
                                   Id = a.ArticleID,
                                   Title = a.Title,
                                   HyperText = a.HyperText,
                                   Description = a.Description,
                                   CreatedAt = a.CreatedAt,
                                   Creator = a.User.FullName
                               }).Where(a => a.Id == id).FirstOrDefault();
            if(listArticle != null)
            {
                return Json(listArticle);
            }
            else
            {
                return BadRequest("Article/Banner is not exist.");
            }
        }

        // Create a new article
        [Route("api/Article")]
        [HttpPost]
        public IHttpActionResult CreateNewArticle([FromBody]ArticleDTO article)
        {
            if (dbContext.Articles.Any(a => a.Image == article.Image))
            {
                return BadRequest("The image already exist.");
            }

            if (article.Title == null)
            {
                return BadRequest("Article title is required fields.");
            }
            if (article.HyperText == null)
            {
                return BadRequest("Article hypertext is required fields.");
            }
            if (article.Description == null)
            {
                return BadRequest("Article description is required fields.");
            }

            var newArticle = new Article();
            newArticle.Title = article.Title;
            newArticle.HyperText = article.HyperText;
            newArticle.Description = article.Description;
            newArticle.Image = article.Image;
            newArticle.CreatedAt = DateTime.Now;
            newArticle.UserID = article.Creator;
            dbContext.Articles.Add(newArticle);
            dbContext.SaveChanges();
            return Ok("Article/Banner has been created successful.");          
        }

        // Update the article
        [Route("api/Article/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateArticle(int id, ArticleDTO article)
        {
            var editArticle = dbContext.Articles.Where(a => a.ArticleID == id).FirstOrDefault();
            if(editArticle != null)
            {
                editArticle.Title = article.Title;
                editArticle.HyperText = article.HyperText;
                editArticle.Description = article.Description;
                editArticle.Image = article.Image;
                editArticle.CreatedAt = DateTime.Now;
                editArticle.UserID = article.Creator;
                dbContext.SaveChanges();
            }
            else
            {
                return BadRequest("Article is not exist.");
            }
            return Ok("Article/Banner has been updated successful.");
        }

        // Delete the article
        [Route("api/Article/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteArticle(int id)
        {
            var editArticle = dbContext.Articles.Where(a => a.ArticleID == id).FirstOrDefault();
            if (editArticle != null)
            {
                dbContext.Articles.Remove(editArticle);
                dbContext.SaveChanges();
            }
            else
            {
                return BadRequest("Not a vilid article id.");
            }
            return Ok("Article/Banner has been deleted successful.");
        }
    }
}
