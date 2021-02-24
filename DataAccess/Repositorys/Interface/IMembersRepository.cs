using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.Interface
{
    public interface IMembersRepository
    {
        Task<MembersModel> GetMemberById(int id);
        Task<List<MembersModel>> GetAllMembers();
        Task<bool> AddMember(MembersModel member);
        Task<bool> UpdateMember(MembersModel member);
        Task<bool> DeleteMemberById(int id);
    }
}
