using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ISqlDataAccess
    {
        Task<List<T>> QueryAsync<T>(string sql);
        Task<bool> SaveAsync<T>(string sql, T parameters);
    }
}