using MediatR;
using QnA_Platform.Application.Features.Questions.Queries.GetQuestionDetail;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Features.Questions
{
    public class GetQuestionDetailQuery: IRequest<GetQuestionDetailResponse>
    {
        public int QuestionId { get; set; }

    }
}
