using Phonebook.Infrastructure.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Infrastructure.Data.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Create a paginated list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> query, int pageIndex, int pageSize)
            where T : class
        {
            return Task.FromResult(PagedList<T>.Create(query, pageIndex, pageSize));
        }
    }
}
