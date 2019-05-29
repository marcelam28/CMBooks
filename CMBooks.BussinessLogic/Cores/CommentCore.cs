using CMBooks.BusinessLogic.Models;
using CMBooks.Common.Response;
using CMBooks.DataLayer.Repositories;
using CMBooks.Models;
using Deventure.BusinessLogic.Core;
using Deventure.DataLayer.EF.Enums;
using System;

namespace CMBooks.BussinessLogic.Cores
{
    public class CommentCore : BaseSinglePkCore<CommentRepository, Comment, DataLayer.Comment>
    {
        public static Response Create(CommentViewModel model)
        {
            var response = ResponseFactory.Success(ResponseCode.SuccessEntityCreated);
            if (model == null)
            {
                return ResponseFactory.Error(ResponseCode.ErrorInvalidInput);
            }

            var comment = model.CopyTo();
            comment.Status = EntityStatus.Active;
            var createdComment = Create(comment);
            
            if (createdComment == null)
            {
                response = ResponseFactory.Error(ResponseCode.ErrorCreatingEntity);
            }
            return response;
        }

        public static Response Delete(Guid commentId)
        {
            var response = false;
            var comment = CommentCore.Get(commentId);
            comment.Status = EntityStatus.Deleted;
            var result = CommentCore.Update(comment);
            if (result != null)
            {
                response = true;
            }

            return ResponseFactory.CreateResponse(response);
        }
    }
}
