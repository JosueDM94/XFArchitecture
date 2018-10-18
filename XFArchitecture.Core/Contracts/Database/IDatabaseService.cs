using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using XFArchitecture.Core.Models;

namespace XFArchitecture.Core.Contracts.Database
{
    public interface IDatabaseService
    {
        Task<bool> InsertUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(User user);
        Task<List<User>> Select();
    }
}
