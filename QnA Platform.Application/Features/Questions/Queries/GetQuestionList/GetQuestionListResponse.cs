using QnA_Platform.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Features.Questions.Queries.GetQuestionList
{
    public class GetQuestionListResponse : BaseResponse 
    {
        public GetQuestionListResponse():base()
        {
                

        }
        public List<QuestionListVm> Questions { get; set; }
    }
}
