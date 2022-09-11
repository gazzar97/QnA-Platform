using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Features.Users.Queries
{
    public class GetIDAfterLoginQuery : IRequest<GetIDAfterLoginQueryResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
