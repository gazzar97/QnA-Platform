using AutoMapper;
using MediatR;
using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Application.Features.Questions.Queries.GetQuestionList;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QnA_Platform.Application.Features.Questions
{
    public class GetQuestionListQueryHandler : IRequestHandler<GetQuestionListQuery, GetQuestionListResponse>
    {
        private readonly IAsyncRepository<Question> _questionRepository;
        
        private readonly IMapper _mapper;

        public GetQuestionListQueryHandler(IAsyncRepository<Question> questionRepository, IMapper mapper)
        {

            _questionRepository = questionRepository;
            _mapper = mapper;
        }
        public async Task<GetQuestionListResponse> Handle(GetQuestionListQuery request, CancellationToken cancellationToken)
        {
            var getQuestionListResponse = new GetQuestionListResponse();

            var allQuestions = (await _questionRepository.ListAllAsync());

            getQuestionListResponse.Questions =  _mapper.Map<List<QuestionListVm>>(allQuestions);

            return getQuestionListResponse;
        }
    }
}
