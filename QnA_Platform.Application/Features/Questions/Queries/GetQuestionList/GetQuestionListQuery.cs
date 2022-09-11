using MediatR;
using QnA_Platform.Application.Features.Questions.Queries.GetQuestionList;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Features.Questions
{
    public class GetQuestionListQuery : IRequest<GetQuestionListResponse>
    {
    }
}
