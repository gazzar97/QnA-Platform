using Moq;
using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QnA_Platform.Application.Unit_Tests.Mocks
{
    public class RepositoryMocks
    {

        public static Mock<IAsyncRepository<Question>> GetQuestionsRepository()
        {
            var questions = new List<Question>
            {
                new Question
                {
                    QuestionId = 1,
                    QuestionHeader = "How are you?"
                },
                new Question
                {
                    QuestionId = 2,
                    QuestionHeader = "How are you"
                },
                new Question
                {
                    QuestionId = 3,
                    QuestionHeader = "How are you"
                },
                new Question
                {
                    QuestionId = 4,
                    QuestionHeader = "How are you"
                },
                new Question
                {
                    QuestionId = 5,
                    QuestionHeader = "How are you"
                }


            };
            var mockQuestionRepository = new Mock<IAsyncRepository<Question>>();

            mockQuestionRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(questions);

            mockQuestionRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(questions[0]);

            mockQuestionRepository.Setup(repo => repo.AddAsync(questions[3])).ReturnsAsync(questions[3]);

            mockQuestionRepository.Setup(repo => repo.DeleteAsync(questions[0]));

            mockQuestionRepository.Setup(repo => repo.AddAsync(It.IsAny<Question>())).ReturnsAsync(
                (Question question) =>
                {
                    questions.Add(question);
                    return question;

                });
            return mockQuestionRepository;



        }

        public static Mock<IAsyncRepository<Answer>> GetAnswersRepository()
        {
            var answers = new List<Answer>
            {
                new Answer
                {
                    AnswerId = 1,
                    AnswerValue = "I am good",
                    VoteScore = 1,
                    QuestionId = 2
                },
                new Answer
                {
                    AnswerId = 2,
                    AnswerValue = "I am good",
                    VoteScore = 5,
                    QuestionId = 1
                },
                new Answer
                {
                    AnswerId = 3,
                    AnswerValue = "I am good",
                    VoteScore = 4,
                    QuestionId = 2
                },
                new Answer
                {
                    AnswerId = 4,
                    AnswerValue = "I am good",
                    VoteScore = 1,
                    QuestionId = 2
                }


            };
            var mockAnswerRepository = new Mock<IAsyncRepository<Answer>>();

            mockAnswerRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(answers);

            mockAnswerRepository.Setup(repo => repo.AddAsync(answers[0])).ReturnsAsync(answers[0]);


            mockAnswerRepository.Setup(repo => repo.AddAsync(It.IsAny<Answer>())).ReturnsAsync(
                (Answer answer) =>
                {
                    answers.Add(answer);
                    return answer;

                });
            return mockAnswerRepository;



        }


    }
}
