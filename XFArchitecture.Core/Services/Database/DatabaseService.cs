using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using XFArchitecture.Core.Models;
using XFArchitecture.Core.Contracts.Database;
using XFArchitecture.Core.Services.Database.Consumer;

namespace XFArchitecture.Core.Services.Database
{
    public class DatabaseService : IDatabaseService
    {
        protected UserConsumer userConsumer;
        protected SchoolConsumer schooconsumer;
        protected StudentConsumer studentConsumer;

        public DatabaseService()
        {
            userConsumer = new UserConsumer();
            schooconsumer = new SchoolConsumer();
            studentConsumer = new StudentConsumer();
        }

        public async Task<bool> InsertUser(User user) => await userConsumer.InserUser(user);

        public async Task<bool> DeleteUser(User user) => await userConsumer.DeleteUser(user);

        public async Task<bool> UpdateUser(User user) => await userConsumer.UpdateUser(user);

        public Task<List<User>> Select() => userConsumer.GetUsers();
    }
}