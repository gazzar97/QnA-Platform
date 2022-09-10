using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Features.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandValidator : AbstractValidator <CreateQuestionCommand>
    {
        public CreateQuestionCommandValidator()
        {
            RuleFor(q => q.QuestionHeader)
             .NotEmpty().WithMessage("{propertyName} is required")
             .NotNull()
             .MaximumLength(150).WithMessage("{propertyName} must not exceed 150 characters");
        }
    }
}
