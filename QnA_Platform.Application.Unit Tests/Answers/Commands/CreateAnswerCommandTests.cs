using AutoMapper;
using Moq;
using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Application.Features.Answers.Commands.CreateAnswer;
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

namespace QnA_Platform.Application.Unit_Tests.Answers.Commands
{
    public class CreateAnswerCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Answer>> _mockAnswerRepository;
        private readonly Mock<IAsyncRepository<Question>> _mockQuestionRepository;


        public CreateAnswerCommandTests()
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
        public async Task CreateQuestionCommandTest()
        {
            var handler = new CreateAnswerCommandHandler(_mockAnswerRepository.Object, _mapper,
                (IAsyncRepository<Question>)_mockQuestionRepository);
            var result = await handler.Handle(new CreateAnswerCommand() { AnswerValue = "Hello",QuestionId = 1,VoteScore = 10 }, CancellationToken.None);

            result.ShouldBeOfType<CreateAnswerCommandResponse>();

            result.Success.ShouldBeTrue();


        }
    }
}
