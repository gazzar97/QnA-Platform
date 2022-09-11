using MediatR;
using QnA_Platform.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QnA_Platform.Application.Features.Users.Queries
{
    public class GetIDAfterLoginQueryHandler : IRequestHandler<GetIDAfterLoginQuery, GetIDAfterLoginQueryResponse>
    {
        private readonly IUserRepository _userReposiory;
        public GetIDAfterLoginQueryHandler(IUserRepository userReposiory)
        {
            _userReposiory = userReposiory;
        }

        public async Task<GetIDAfterLoginQueryResponse> Handle(GetIDAfterLoginQuery request, CancellationToken cancellationToken)
        {
            var getIDAfterLogingQUeryResponse = new GetIDAfterLoginQueryResponse();
            var guid = await _userReposiory.GetGuidBaseOnUserCredential(request.UserName, request.Password);
            if(guid == null)
            {
                getIDAfterLogingQUeryResponse.Success = false;
                getIDAfterLogingQUeryResponse.Message = $"There is no user with the following credential, UserName:{request.UserName}";
                getIDAfterLogingQUeryResponse.Guid = Guid.Empty;
            }
            else
            {
                getIDAfterLogingQUeryResponse.Message = $"the following UserName:{request.UserName} is found";
                getIDAfterLogingQUeryResponse.Guid = guid;
            }
            return getIDAfterLogingQUeryResponse;

        }
    }
}
