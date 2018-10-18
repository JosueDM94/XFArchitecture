using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using XFArchitecture.Core.Services.Database.Context;

namespace XFArchitecture.Core.Services.Database.Consumer
{
    public class BaseConsumer<T> : IDisposable where T : class
    {
        protected BaseContext context;
        public BaseConsumer()
        {
            context = BaseContext.Create();
        }

        protected async Task<bool> UpdateRow(T item)
        {
            context.Entry(item).State = EntityState.Deleted;
            return await Save();
        }

        protected async Task<bool> InsertRow(T item)
        {
            context.Entry(item).State = EntityState.Added;
            return await Save();
        }

        protected async Task<bool> DeleteRow(T item)
        {
            context.Entry(item).State = EntityState.Deleted;
            return await Save();
        }

        protected async Task<bool> Save()
        {
            return (await context.SaveChangesAsync() >= 0);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
