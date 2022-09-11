using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Features.Questions
{
    public class QuestionDetailVm
    {

        public string QuestionHeader { get; set; }

        public List<AnswerQuestionDto> Answers { get; set; }
    }
}
