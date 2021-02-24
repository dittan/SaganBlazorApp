using Dapper;
using DataAccess.Models;
using DataAccess.Repositorys.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys
{
    public class MembersRepository : IMembersRepository
    {
        private readonly IConfiguration _config;
        private readonly string DbConnectionString = "SaganDb";

        public MembersRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> AddMember(MembersModel member)
        {
            string connectionString = _config.GetConnectionString(DbConnectionString);

            const string sql = "INSERT INTO Members (NickName, FirstName, LastName, DateOfBirth, City, Country, Image) VALUES (@NickName, @FirstName, @LastName, @DateOfBirth, @City, @Country, @Image)";

            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                var affectedRows = await connection.ExecuteAsync(sql, member);

                if (affectedRows > 0) return true;
                else return false;
            }
        }

        public async Task<bool> DeleteMemberById(int id)
        {
            string connectionString = _config.GetConnectionString(DbConnectionString);

            const string sql = "DELETE FROM Members WHERE Id = @Id";

            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });

                if (affectedRows > 0) return true;
                else return false;
            }
        }

        public async Task<List<MembersModel>> GetAllMembers()
        {
            string connectionString = _config.GetConnectionString(DbConnectionString);

            const string sql = "SELECT [Id],[NickName],[FirstName],[LastName],[DateOfBirth],[City],[Country],[Image] FROM [Members]";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var members = await connection.QueryAsync<MembersModel>(sql);

                return members.ToList();
            }
        }

        public async Task<MembersModel> GetMemberById(int id)
        {
            string connectionString = _config.GetConnectionString(DbConnectionString);

            const string sql = "SELECT [Id],[NickName],[FirstName],[LastName],[DateOfBirth],[City],[Country],[Image] FROM [Members] WHERE Id = @Id";

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var member = await connection.QuerySingleAsync<MembersModel>(sql, new { Id = id});

                return member;
            }
        }

        public async Task<bool> UpdateMember(MembersModel member)
        {
            string connectionString = _config.GetConnectionString(DbConnectionString);

            const string sql = @"UPDATE Members SET NickName = @NickName, FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, City = @City
                , Country = @Country, Image = @Image WHERE Id = @Id";


            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var affectedRows = await connection.ExecuteAsync(sql, member);

                if (affectedRows > 0) return true;
                else return false;
            }
        }
    }
}
