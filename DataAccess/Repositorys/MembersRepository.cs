using DataAccess.Models;
using DataAccess.Repositorys.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys
{
    public class MembersRepository : IMembersRepository
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public MembersRepository(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<bool> AddMember(MembersModel member)
        {
            const string sql = "INSERT INTO Members (NickName, FirstName, LastName, DateOfBirth, City, Country, Image) VALUES (@NickName, @FirstName, @LastName, @DateOfBirth, @City, @Country, @Image)";

            var result = await _sqlDataAccess.SaveAsync(sql, member);

            return result;
        }

        public async Task<List<MembersModel>> GetAllMembers()
        {
            const string sql = "SELECT [NickName],[FirstName],[LastName],[DateOfBirth],[City],[Country],[Image] FROM [Members]";

            var data = await _sqlDataAccess.QueryAsync<MembersModel>(sql);

            return data;
        }
    }
}
