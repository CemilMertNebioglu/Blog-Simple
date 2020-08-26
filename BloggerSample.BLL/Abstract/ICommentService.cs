

using BloggerSample.Core.Services;
using BloggerSample.DTO;
using System.Collections.Generic;

namespace BloggerSample.BLL.Abstract
{
    public interface ICommentService : IServiceBase
    {
        List<CommentDTO> getAll();
        CommentDTO getComment(int Id);
        List<CommentDTO> getByArticleId(int Id);
        CommentDTO newComment(CommentDTO Comment);
        CommentDTO updateComment(CommentDTO Comment);
        bool deleteComment(int commentId);
        bool markasRead(int commentId);
    }
}
