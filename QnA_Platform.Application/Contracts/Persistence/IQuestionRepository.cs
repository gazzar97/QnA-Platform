using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Application.Contracts.Persistence
{
    public interface IQuestionRepository: IAsyncRepository<Question>
    {

    }
}
