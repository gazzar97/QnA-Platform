using AutoMapper;
using Moq;
using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Application.Features.Questions;
using QnA_Platform.Application.Features.Questions.Queries.GetQuestionList;
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
    public class GetQuestionsListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Question>> _mockQuestionRepository;


        public GetQuestionsListQueryHandlerTests()
        {

            _mockQuestionRepository = RepositoryMocks.GetQuestionsRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();

        }

        [Fact]
        public async Task GetQuestionsListTest()
        {
            var handler = new GetQuestionListQueryHandler(_mockQuestionRepository.Object, _mapper);
            var result = await handler.Handle(new GetQuestionListQuery(),CancellationToken.None);

            result.ShouldBeOfType<GetQuestionListResponse>();

            result.Questions.Count.ShouldBe(5);

        }

    }
}
