using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QnA_Platform.Application.Features.Questions;
using QnA_Platform.Application.Features.Questions.Commands.CreateQuestion;
using QnA_Platform.Application.Features.Questions.Commands.DeleteQuestion;
using QnA_Platform.Application.Features.Questions.Queries.GetQuestionList;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QnA_Platform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("all", Name = "GetAllQuestions")]
        public async Task<ActionResult<GetQuestionListResponse>> GetAllQuestions()
        {
            try
            {
                var getQuestionListResponse = await _mediator.Send(new GetQuestionListQuery());
                return Ok(getQuestionListResponse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<QuestionDetailVm>> GetQuestion(int id)
        {
            try
            {
                var question = await _mediator.Send(new GetQuestionDetailQuery() { QuestionId = id});
                if (question == null) return NotFound();
                else
                {
                    return Ok(question);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<CreateQuestionCommandResponse>> AddQuestion([FromBody] Question question)
        {
            try
            {
                if (question == null) return BadRequest();
                else
                {
                    var createQuestionCommandResponse = await _mediator.Send(new CreateQuestionCommand() { QuestionHeader = question.QuestionHeader });
                    return createQuestionCommandResponse;

                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error createing a new Question record");

            }


        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DeleteQuestionCommandResponse>> DeleteQuestion(int id)
        {
            try
            {
                var deleteQuestionCommandResponse = await _mediator.Send(new DeleteQuestionCommand() { QuestionId = id });
                return deleteQuestionCommandResponse;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error createing a new Question record");

            }


        }



    }
}
