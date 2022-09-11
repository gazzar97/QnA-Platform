using AutoMapper;
using Moq;
using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Application.Features.Questions.Commands.CreateQuestion;
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

namespace QnA_Platform.Application.Unit_Tests.Questions.Commands
{
    public class CreateQuestionCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Question>> _mockQuestionRepository;
        

        public CreateQuestionCommandTests()
        {

            _mockQuestionRepository = RepositoryMocks.GetQuestionsRepository();
            
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();


        }
        [Fact]
        public async Task CreateQuestionCommandTest()
        {
            var handler = new CreateQuestionCommandHandler(_mapper,_mockQuestionRepository.Object);
            var result = await handler.Handle(new CreateQuestionCommand() { QuestionHeader = "Hello" }, CancellationToken.None);

            result.ShouldBeOfType<CreateQuestionCommandResponse>();

            result.Question.QuestionHeader.ShouldBe("Hello");


        }


    }
}
