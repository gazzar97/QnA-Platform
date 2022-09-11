using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Features.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommandValidator : AbstractValidator<CreateAnswerCommand>
    {
        public CreateAnswerCommandValidator()
        {
            RuleFor(q => q.AnswerValue)
             .NotEmpty().WithMessage("{propertyName} is required")
             .NotNull()
             .MaximumLength(250).WithMessage("{propertyName} must not exceed 150 characters");


            RuleFor(q => q.QuestionId)
             .NotEmpty().WithMessage("{propertyName} is required")
             .NotNull();
         
        }

    }
}
