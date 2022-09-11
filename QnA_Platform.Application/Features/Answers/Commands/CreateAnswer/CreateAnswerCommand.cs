using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Features.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommand: IRequest<CreateAnswerCommandResponse>
    {

        public string AnswerValue { get; set; }
        public int QuestionId { get; set; }
        public int VoteScore { get; set; }
    }
    
}
