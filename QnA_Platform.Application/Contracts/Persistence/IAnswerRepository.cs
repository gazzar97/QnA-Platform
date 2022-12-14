using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QnA_Platform.Application.Contracts.Persistence
{
    public interface IAnswerRepository:IAsyncRepository<Answer>
    {
        List<Answer> ListAllByQuestionIdAsync(int Id);
    }
}
