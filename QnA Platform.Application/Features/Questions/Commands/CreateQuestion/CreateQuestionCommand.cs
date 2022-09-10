using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Features.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommand : IRequest<CreateQuestionCommandResponse>
    {
        public string QuestionHeader { get; set; }
       

        public override string ToString()
        {
            return $"Question Header : {QuestionHeader}";
        }
    }
}
