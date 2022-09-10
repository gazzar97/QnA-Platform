using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Persistence.Repositories
{
    public class QuestionRepository : BaseRepository<Question> , IQuestionRepository
    {
        public QuestionRepository(QnADbContext context) 
            : base(context)
        {
               
        }
    }
}
