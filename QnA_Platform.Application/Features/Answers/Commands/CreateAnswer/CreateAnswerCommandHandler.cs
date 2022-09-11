using AutoMapper;
using MediatR;
using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QnA_Platform.Application.Features.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, CreateAnswerCommandResponse>
    {
        private readonly IAsyncRepository<Answer> _answerRepository;
        private readonly IAsyncRepository<Question> _questionRepository;
        private readonly IMapper _mapper;

        public CreateAnswerCommandHandler(IAsyncRepository<Answer> answerRepository, IMapper mapper, IAsyncRepository<Question> questionRepository)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
            _questionRepository = questionRepository;
        }
        public CreateAnswerCommandHandler(IAsyncRepository<Answer> answerRepository, IMapper mapper)
        {

            _answerRepository = answerRepository;
            _mapper = mapper;
        }
        public async Task<CreateAnswerCommandResponse> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            var createAnswerCommandResponse = new CreateAnswerCommandResponse();

            var validator = new CreateAnswerCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            var question = await _questionRepository.GetByIdAsync(request.QuestionId);
            if (validatorResult.Errors.Count > 0 || question == null)
            {
                createAnswerCommandResponse.Success = false;
                createAnswerCommandResponse.Message = $"Question with the following Id:{request.QuestionId} is not found";
                createAnswerCommandResponse.ValidaitonErrors = new List<string>();
                foreach (var error in validatorResult.Errors)
                {
                    createAnswerCommandResponse.ValidaitonErrors.Add(error.ErrorMessage);
                }
            }
            if (createAnswerCommandResponse.Success == true)
            {
                var answer = new Answer() { AnswerValue = request.AnswerValue, QuestionId = request.QuestionId , VoteScore = request.VoteScore};

                answer = await _answerRepository.AddAsync(answer);
                createAnswerCommandResponse.Answer = answer;

            }


            return createAnswerCommandResponse;

        }
    }
}
