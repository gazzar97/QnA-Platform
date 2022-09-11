using QnA_Platform.Application.Responses;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Features.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandResponse : BaseResponse
    {
        public CreateQuestionCommandResponse() : base()
        {

        }
        public Question Question { get; set; }
    }
}
