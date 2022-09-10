using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QnA_Platform.Application.Features.Answers.Commands.CreateAnswer;
using QnA_Platform.Application.Features.Answers.Commands.DeleteAnswer;
using QnA_Platform.Application.Features.Answers.Commands.UpdateAnswerVoteScore;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QnA_Platform.API.Controllers
{
    [Route("api/questions/{id}/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnswersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<CreateAnswerCommandResponse>> AddAnswer([FromBody] AnswerDto answer, int id)
        {
            try
            {
                if (answer == null) return BadRequest();
                else
                {
                    var createQuestionCommandResponse = await _mediator.Send(new CreateAnswerCommand() { AnswerValue = answer.AnswerValue, QuestionId = id, VoteScore = 0 });
                    return createQuestionCommandResponse;

                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error createing a new Answer record");

            }

        }
        [HttpDelete("{AnswerId}")]
        public async Task<ActionResult<DeleteAnswerCommandResponse>> DeleteAnswer(int AnswerId,int id)
        {
            try
            {
                var deleteAnswerCommandResponse = await _mediator.Send(new DeleteAnswerCommand() { AnswerId = AnswerId , QuestionId = id});
                return deleteAnswerCommandResponse;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error createing a new Question record");

            }


        }
        [HttpPut("{AnswerID}/votes", Name = "UpdateAnswerVoteScore")]
        public async Task<ActionResult<UpdateAnswerVoteScoreCommandResponse>> UpdateAnswerVoteScore([FromBody] AnswerVoteScoreDto answer, int id,int AnswerID)
        {

            try
            {
                var updateAnswerVoteScoreCommandResponse = await _mediator.Send(new UpdateAnswerVoteScoreCommand() 
                { AnswerId = AnswerID, QuestionId = id,VoteScore = Convert.ToInt32(answer.VoteScore) });
                return updateAnswerVoteScoreCommandResponse;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error createing a new Question record");

            }

        }

    }
}
