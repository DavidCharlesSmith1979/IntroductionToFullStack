using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly fullstackdemoContext _fullstackdemoContext;

        public UserRepository(fullstackdemoContext fullstackdemoContext)
        {
            _fullstackdemoContext = fullstackdemoContext;
        }

        public async Task<List<User>> Get()
        {
            return await _fullstackdemoContext.Users.ToListAsync();
        }

        public async Task<User> Get(long id)
        {
            return await _fullstackdemoContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> Create(User user)
        {
            await _fullstackdemoContext.Users.AddAsync(user);

            await _fullstackdemoContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Update(User user)
        {
            _fullstackdemoContext.Attach(user);

            _fullstackdemoContext.Entry(user).Property(x => x.FirstName).IsModified = true;
            _fullstackdemoContext.Entry(user).Property(x => x.LastName).IsModified = true;

            var writeCount = await _fullstackdemoContext.SaveChangesAsync();

            return writeCount == 1;
        }

        public async Task<bool> Delete(long id)
        {
            var user = new User { Id = id };

            _fullstackdemoContext.Entry(user).State = EntityState.Deleted;

            var writeCount = await _fullstackdemoContext.SaveChangesAsync();

            return writeCount == 1;
        }
    }
}
