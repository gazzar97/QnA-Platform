using QnA_Platform.Application.Responses;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Features.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommandResponse : BaseResponse
    {
        public CreateAnswerCommandResponse() : base()
        {

        }
        public Answer Answer { get; set; }
    }
}
