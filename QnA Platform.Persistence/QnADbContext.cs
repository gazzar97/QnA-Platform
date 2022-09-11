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
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserName = "user1",
                    Password = "123"
                },
                new User
                {
                    UserName = "user2",
                    Password = "123"
                },
                new User
                {
                    UserName = "user3",
                    Password = "123"
                },
                new User
                {
                    UserName = "user4",
                    Password = "123"
                },
                new User
                {
                    UserName = "user5",
                    Password = "123"
                }
               );
        }
    }
}
