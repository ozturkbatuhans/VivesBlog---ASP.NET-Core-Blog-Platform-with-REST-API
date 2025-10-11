using Microsoft.EntityFrameworkCore;
using VivesBlog.Model;
using VivesBlog.Repository;

namespace VivesBlog.Services
{
    public class ArticleService
    {
        private readonly VivesBlogDbContext _dbContext;

        public ArticleService(VivesBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IList<Article> Find()
        {
            return _dbContext.Articles
                .Include(a => a.Author)
                .ToList();
        }

        public Article? Get(int id)
        {
            return _dbContext.Articles
                .Include(a => a.Author)
                .FirstOrDefault(a => a.Id == id);
        }

        public Article? Create(Article article)
        {
            article.CreatedDate = DateTime.Now;

            _dbContext.Articles.Add(article);
            _dbContext.SaveChanges();

            return article;
        }



        public Article? Update(int id, Article article)
        {
            var dbArticle = Get(id);

            if (dbArticle == null)
            {
                return null;
            }

            dbArticle.Title = article.Title;
            dbArticle.Content = article.Content;
            dbArticle.AuthorId = article.AuthorId;

            _dbContext.SaveChanges();

            return dbArticle;
        }

        public void Delete(int id)
        {
            var article = Get(id);

            if (article is null)
            {
                return;
            }

            _dbContext.Articles.Remove(article);

            _dbContext.SaveChanges();
        }
    }
}
