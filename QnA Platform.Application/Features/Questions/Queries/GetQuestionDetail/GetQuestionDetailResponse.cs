using QnA_Platform.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Features.Questions.Queries.GetQuestionDetail
{
    public class GetQuestionDetailResponse : BaseResponse
    {
        public GetQuestionDetailResponse(): base()
        {

        }
        public QuestionDetailVm QuestionDetail { get; set; }
    }
}
