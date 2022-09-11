using AutoMapper;
using Moq;
using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Application.Features.Questions;
using QnA_Platform.Application.Features.Questions.Queries.GetQuestionDetail;
using QnA_Platform.Application.Profiles;
using QnA_Platform.Application.Unit_Tests.Mocks;
using QnA_Platform.Domain.Entities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace QnA_Platform.Application.Unit_Tests.Questions.Queries
{

    public class GetQuestionDetailQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Question>> _mockQuestionRepository;
        private readonly Mock<IAnswerRepository> _mockAnswerRepository;

        public GetQuestionDetailQueryHandlerTests()
        {

            _mockQuestionRepository = RepositoryMocks.GetQuestionsRepository();
            _mockAnswerRepository = RepositoryMocks.GetAnswersRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetQuestionDetailTest()
        {
            var handler = new GetQuestionDetailQueryHandler(_mockQuestionRepository.Object, _mapper);
            var result = await handler.Handle(new GetQuestionDetailQuery() { QuestionId = 1}, CancellationToken.None);

            result.ShouldBeOfType<GetQuestionDetailResponse>();
            
            result.QuestionDetail.QuestionHeader.ShouldBe("How are you?");
            
        }


    }
}
