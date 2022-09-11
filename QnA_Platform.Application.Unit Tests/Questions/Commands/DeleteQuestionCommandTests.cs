using AutoMapper;
using Moq;
using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Application.Features.Questions.Commands.DeleteQuestion;
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
    public class DeleteQuestionCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Question>> _mockQuestionRepository;

        public DeleteQuestionCommandTests()
        {
            _mockQuestionRepository = RepositoryMocks.GetQuestionsRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();

        }
        [Fact]
        public async Task DeleteQuestionCommandTest()
        {

            var handler = new DeleteQuestionCommandHandler(_mockQuestionRepository.Object, _mapper);
            var result = await handler.Handle(new DeleteQuestionCommand() { QuestionId = 1 }, CancellationToken.None);

            result.ShouldBeOfType<DeleteQuestionCommandResponse>();

            result.Success.ShouldBeTrue();

        }
    }
}
