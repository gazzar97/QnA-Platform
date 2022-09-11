using AutoMapper;
using MediatR;
using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QnA_Platform.Application.Features.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, DeleteQuestionCommandResponse>
    {

        private readonly IAsyncRepository<Question> _questionRepository;
        private readonly IMapper _mapper;

        public DeleteQuestionCommandHandler(IAsyncRepository<Question> questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }
        public async Task<DeleteQuestionCommandResponse> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var deleteQuestionCommandResponse = new DeleteQuestionCommandResponse();


            var questionToDelete = await _questionRepository.GetByIdAsync(request.QuestionId);
            if(questionToDelete == null)
            {
                deleteQuestionCommandResponse.Success = false;
                deleteQuestionCommandResponse.Message = $"Question with the following ID :{request.QuestionId} is not found";
            }
            else
            {

                await _questionRepository.DeleteAsync(questionToDelete);
                deleteQuestionCommandResponse.Message = $"Question with the following ID :{request.QuestionId} is delteted successfully";

            }



            return deleteQuestionCommandResponse;

        }
    }
}
