using System;
using System.Collections.Generic;
using System.Text;
using Trackr.Infrastructure.Dtos.Comment;

namespace Trackr.Infrastructure.Services
{
    public interface ICommentService
    {
        CommentResultDto Create(CommentDto comment);
    }
}
