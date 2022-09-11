using QnA_Platform.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Features.Users.Queries
{
    public class GetIDAfterLoginQueryResponse : BaseResponse
    {
        public GetIDAfterLoginQueryResponse(): base()
        {

        }
        public Guid Guid { get; set; }
    }
}
