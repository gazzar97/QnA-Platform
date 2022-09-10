using AutoMapper;
using MediatR;
using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QnA_Platform.Application.Features.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand>
    {
        private readonly IAsyncRepository<Question> _questionRepository;
        private readonly IMapper _mapper;
        public UpdateQuestionCommandHandler(IMapper mapper, IAsyncRepository<Question> questionRepository)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
        }

        public async Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var questionToUpdate = await _questionRepository.GetByIdAsync(request.QuestionId);

            _mapper.Map(request,questionToUpdate,typeof(UpdateQuestionCommand),typeof(Question));
            await _questionRepository.UpdateAsync(questionToUpdate);
            return Unit.Value;
        }
    }
}
