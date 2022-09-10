using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Features.Answers.Commands.DeleteAnswer
{
    public class DeleteAnswerCommand : IRequest<DeleteAnswerCommandResponse>
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
    }
}
