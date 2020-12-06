using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        private readonly string DbConnectionString = "SaganDb";

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> QueryAsync<T>(string sql)
        {
            string connectionString = _config.GetConnectionString(DbConnectionString);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql);

                return data.ToList();
            }
        }

        public async Task<bool> SaveAsync<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(DbConnectionString);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var affectedRows = await connection.ExecuteAsync(sql, parameters);

                if (affectedRows > 0) return true;
                else return false;
            }
        }
    }
}
