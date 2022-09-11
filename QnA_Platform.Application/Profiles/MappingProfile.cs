using AutoMapper;
using QnA_Platform.Application.Features.Answers.Commands.UpdateAnswerVoteScore;
using QnA_Platform.Application.Features.Questions;
using QnA_Platform.Application.Features.Questions.Commands.CreateQuestion;
using QnA_Platform.Application.Features.Questions.Commands.UpdateQuestion;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Question, QuestionListVm>().ReverseMap();
            CreateMap<Question, QuestionDetailVm>().ReverseMap();
            CreateMap<Answer, AnswerQuestionDto>().ReverseMap();
            CreateMap<Question, CreateQuestionCommand>().ReverseMap();
            CreateMap<Question, UpdateQuestionCommand>().ReverseMap();
            CreateMap<Answer, UpdateAnswerVoteScoreCommand>().ReverseMap();
        }
    }
}
