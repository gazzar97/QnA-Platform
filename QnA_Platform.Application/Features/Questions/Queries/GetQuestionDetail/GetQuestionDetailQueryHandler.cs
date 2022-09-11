using AutoMapper;
using MediatR;
using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Application.Features.Questions.Queries.GetQuestionDetail;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QnA_Platform.Application.Features.Questions
{
    public class GetQuestionDetailQueryHandler : IRequestHandler<GetQuestionDetailQuery, GetQuestionDetailResponse>
    {
        private readonly IAsyncRepository<Question> _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public GetQuestionDetailQueryHandler(IAsyncRepository<Question> questionRepository, IMapper mapper,
            IAnswerRepository answerRepository)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
                
        }
        public GetQuestionDetailQueryHandler(IAsyncRepository<Question> questionRepository, IMapper mapper)
        {

            _mapper = mapper;
            _questionRepository = questionRepository;
        }
        public async Task<GetQuestionDetailResponse> Handle(GetQuestionDetailQuery request, CancellationToken cancellationToken)
        {
            var getQuestionDetailResponse = new GetQuestionDetailResponse();


            var question = await _questionRepository.GetByIdAsync(request.QuestionId);
            if (question == null)
            {
                getQuestionDetailResponse.Success = false;
                getQuestionDetailResponse.Message = $"Question with the following ID:{request.QuestionId} not found";

            }
            else
            {
                var questionDetailDto = _mapper.Map<QuestionDetailVm>(question);

                //var answers = _answerRepository.ListAllByQuestionIdAsync(request.QuestionId);

               // questionDetailDto.Answers = _mapper.Map<List<AnswerQuestionDto>>(answers);
                getQuestionDetailResponse.Message = $"Question with the following ID:{request.QuestionId} is found";
                getQuestionDetailResponse.QuestionDetail = questionDetailDto;

            }
                return getQuestionDetailResponse;
        }
    }
}
