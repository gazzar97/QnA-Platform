using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnA_Platform.Persistence
{
    public  static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<QnADbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("default"))
            );


            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            
            return services;
        }

    }
}
