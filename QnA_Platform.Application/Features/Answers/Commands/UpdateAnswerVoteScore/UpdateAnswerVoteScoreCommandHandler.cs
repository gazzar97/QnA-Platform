using AutoMapper;
using MediatR;
using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QnA_Platform.Application.Features.Answers.Commands.UpdateAnswerVoteScore
{
    public class UpdateAnswerVoteScoreCommandHandler : IRequestHandler<UpdateAnswerVoteScoreCommand, UpdateAnswerVoteScoreCommandResponse>
    {

        private readonly IAsyncRepository<Answer> _answerRepository;
        private readonly IAsyncRepository<Question> _questionRepository;

        private readonly IMapper _mapper;
        public UpdateAnswerVoteScoreCommandHandler(IAsyncRepository<Answer> answerRepository, IMapper mapper, IAsyncRepository<Question> questionRepository)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
            _questionRepository = questionRepository;
        }
        public async Task<UpdateAnswerVoteScoreCommandResponse> Handle(UpdateAnswerVoteScoreCommand request, CancellationToken cancellationToken)
        {
            var updateAnswerVoteScoreResponse = new UpdateAnswerVoteScoreCommandResponse();

            var question = await _questionRepository.GetByIdAsync(request.QuestionId);
            var answerToUpdate = await _answerRepository.GetByIdAsync(request.AnswerId);

            if (answerToUpdate == null && question == null)
            {
                updateAnswerVoteScoreResponse.Success = false;

                updateAnswerVoteScoreResponse.Message = $"Question with the following ID :{request.QuestionId} is not found and Answer with the following Id :{request.AnswerId} is not found";
            }
            else if (question == null)
            {
                updateAnswerVoteScoreResponse.Success = false;

                updateAnswerVoteScoreResponse.Message = $"Question with the following ID :{request.QuestionId} is not found";

            }
            else if (answerToUpdate == null)
            {
                updateAnswerVoteScoreResponse.Success = false;

                updateAnswerVoteScoreResponse.Message = $"Answer with the following Id :{request.AnswerId} is not found";
            }
            else
            {

                _mapper.Map(request, answerToUpdate, typeof(UpdateAnswerVoteScoreCommand), typeof(Answer));
                await _answerRepository.UpdateAsync(answerToUpdate);
        
                updateAnswerVoteScoreResponse.Message = $"Answer VoteScore field with the following ID :{request.AnswerId} is updated successfully";

            }

            return updateAnswerVoteScoreResponse;
        }
    }
}
