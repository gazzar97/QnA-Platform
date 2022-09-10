using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnA_Platform.Persistence.Repositories
{
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        protected readonly QnADbContext _context;
        public AnswerRepository(QnADbContext context)
            :base(context)
        {
            _context = context;
        }
        public  List<Answer> ListAllByQuestionIdAsync(int Id)
        {
            var allAnswersBasedOnQuestionId =  ( _context.Answers.Where(ans => ans.QuestionId == Id).ToList());

            return allAnswersBasedOnQuestionId;
        }
    }
}
