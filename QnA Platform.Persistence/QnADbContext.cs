using Microsoft.EntityFrameworkCore;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Persistence
{
    public class QnADbContext: DbContext
    {
        public QnADbContext(DbContextOptions<QnADbContext> options)
            :base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

    }
}
