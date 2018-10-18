using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using XFArchitecture.Core.Models;

namespace XFArchitecture.Core.Services.Database.Consumer
{
    public class UserConsumer : BaseConsumer<User>
    {
        public async Task<bool> InserUser(User user)
        {
            return await InsertRow(user);
        }

        public async Task<bool> DeleteUser(User user)
        {
            return await DeleteRow(user);
        }

        public async Task<bool> UpdateUser(User user)
        {
            return await UpdateRow(user);
        }

        public async Task<List<User>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }
    }
}