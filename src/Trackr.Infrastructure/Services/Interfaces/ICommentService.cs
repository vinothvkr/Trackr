using System;
using System.Collections.Generic;
using System.Text;
using Trackr.Infrastructure.Dtos.Comment;

namespace Trackr.Infrastructure.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentResultDto> GetAll(int projectId, int issueId);
        CommentResultDto Create(CommentDto comment);
    }
}
