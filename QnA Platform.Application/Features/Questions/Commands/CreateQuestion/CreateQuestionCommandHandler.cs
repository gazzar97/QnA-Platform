using AutoMapper;
using MediatR;
using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QnA_Platform.Application.Features.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, CreateQuestionCommandResponse>
    {
        private readonly IAsyncRepository<Question> _questionRepository;
        private readonly IMapper _mapper;

        public CreateQuestionCommandHandler(IMapper mapper, IAsyncRepository<Question> questionRepository)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
        }

        public async Task<CreateQuestionCommandResponse> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var createQuestionCommandResponse = new CreateQuestionCommandResponse();

            var validator = new CreateQuestionCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
            {
                createQuestionCommandResponse.Success = false;
                createQuestionCommandResponse.ValidaitonErrors = new List<string>();
                foreach (var error in validatorResult.Errors)
                {
                    createQuestionCommandResponse.ValidaitonErrors.Add(error.ErrorMessage);
                }
            }
            if(createQuestionCommandResponse.Success == true)
            {
                var question = new Question() { QuestionHeader = request.QuestionHeader };

                question = await _questionRepository.AddAsync(question);
                createQuestionCommandResponse.Question = question;

            }

            
            return createQuestionCommandResponse;
        }

    }
}
