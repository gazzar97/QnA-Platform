using QnA_Platform.Application.Contracts.Persistence;
using QnA_Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QnA_Platform.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        protected readonly QnADbContext _context;

        public UserRepository(QnADbContext context) :base(context)
        {
            _context = context;
        }
        public async Task<Guid> GetGuidBaseOnUserCredential(string UserName, string Password)
        {

            var user = await _context.Users.FindAsync(UserName);

            if(user != null && user.Password == Password)
            {
                return Guid.NewGuid();
            }
            else
            {
                return Guid.Empty;
            }
        }
    }
}
