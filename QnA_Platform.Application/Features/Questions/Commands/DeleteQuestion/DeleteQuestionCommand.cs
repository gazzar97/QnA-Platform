using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Features.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommand : IRequest<DeleteQuestionCommandResponse>
    {
        public int QuestionId { get; set; }
    }
}
