using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Features.Answers.Commands.UpdateAnswerVoteScore
{
    public class UpdateAnswerVoteScoreCommand : IRequest<UpdateAnswerVoteScoreCommandResponse>
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public int VoteScore { get; set; }
    }
}
