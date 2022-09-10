using AutoMapper;
using MediatR;
using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QnA_Platform.Application.Features.Answers.Commands.DeleteAnswer
{
    public class DeleteAnswerCommandHandler : IRequestHandler<DeleteAnswerCommand, DeleteAnswerCommandResponse>
    {
        private readonly IAsyncRepository<Answer> _answerRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public DeleteAnswerCommandHandler(IAsyncRepository<Answer> answerRepository, IMapper mapper, IQuestionRepository questionRepository)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
            _questionRepository = questionRepository;
        }
        public async Task<DeleteAnswerCommandResponse> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            var deleteAnswerCommandResponse = new DeleteAnswerCommandResponse();


            var answerToDelete = await _answerRepository.GetByIdAsync(request.AnswerId);
            var question = await _questionRepository.GetByIdAsync(request.QuestionId);
            
            if (answerToDelete == null && question == null)
            {
                deleteAnswerCommandResponse.Success = false;
                
                deleteAnswerCommandResponse.Message = $"Question with the following ID :{request.QuestionId} is not found and Answer with the following Id :{request.AnswerId} is not found";
            }
            else if (question == null)
            {
                deleteAnswerCommandResponse.Success = false;

                deleteAnswerCommandResponse.Message = $"Question with the following ID :{request.QuestionId} is not found";

            }
            else if (answerToDelete == null)
            {
                deleteAnswerCommandResponse.Success = false;

                deleteAnswerCommandResponse.Message = $"Answer with the following Id :{request.AnswerId} is not found";
            }
            else
            {

                await _answerRepository.DeleteAsync(answerToDelete);
                deleteAnswerCommandResponse.Message = $"Question with the following ID :{request.AnswerId} is delteted successfully";

            }



            return deleteAnswerCommandResponse;


        }
    }
}
