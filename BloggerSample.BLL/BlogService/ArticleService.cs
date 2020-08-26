using BloggerSample.BLL.Abstract;
using BloggerSample.Core.Data.UnitOfWork;
using BloggerSample.DTO;
using BloggerSample.Model;
using BloggerSample.Mapping;
using BloggerSample.Mapping.ConfigProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloggerSample.BLL.BlogService
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitofWork uow;
        public ArticleService(IUnitofWork _uow)
        {
            uow = _uow;
        }
        public bool deleteArticle(int articleId)
        {
            try
            {
                var article = uow.GetRepository<Article>().Get(z => z.Id == articleId);
                uow.GetRepository<Article>().Delete(article);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<ArticleDTO> getAll()
        {
            var articleList = uow.GetRepository<Article>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<ArticleDTO>>(articleList);
        }

        public ArticleDTO getArticle(int Id)
        {
            var article = uow.GetRepository<Article>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<ArticleDTO>(article);
        }

        public List<ArticleDTO> getArticleName(string articleName)
        {
            var articleList = uow.GetRepository<Article>().Get(z => z.Title.Contains(articleName), null).ToList();
            return MapperFactory.CurrentMapper.Map<List<ArticleDTO>>(articleList); 
        }

        public ArticleDTO newArticle(ArticleDTO article)
        {
            if (!uow.GetRepository<Article>().GetAll().Any(z => z.Title == article.Title))
            {
                var added = MapperFactory.CurrentMapper.Map<Article>(article);
                added = uow.GetRepository<Article>().Add(added);
                uow.SaveChanges();
                return  MapperFactory.CurrentMapper.Map<ArticleDTO>(added);

            }
            else
            {
                return null;
            }
        }

        public ArticleDTO updateArticle(ArticleDTO article)
        {
            var selected = uow.GetRepository<Article>().Get(z => z.Id == article.Id);
            selected = MapperFactory.CurrentMapper.Map<Article>(article);
            uow.GetRepository<Article>().Update(selected);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<ArticleDTO>(selected);
        }
    }
}
