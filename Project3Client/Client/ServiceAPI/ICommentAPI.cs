using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
using Client.DTO;
namespace Client.ServiceAPI
{
    public interface ICommentAPI
    {
        List<Comment> FindAll();
        string Create(Comment cmt);
        List<CommentDTO> FindAll2();

    }
}
