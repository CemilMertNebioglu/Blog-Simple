

using BloggerSample.Core.Services;
using BloggerSample.DTO;
using System.Collections.Generic;

namespace BloggerSample.BLL.Abstract
{
    public interface IArticleService : IServiceBase
    {
        List<ArticleDTO> getAll();
        ArticleDTO getArticle(int articleId);
        List<ArticleDTO> getArticleName(string articleName);
        ArticleDTO newArticle(ArticleDTO article);
        ArticleDTO updateArticle(ArticleDTO article);
        bool deleteArticle(int articleId);
    }
}
