using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.Interface
{
    public interface IMembersRepository
    {
        Task<List<MembersModel>> GetAllMembers();
    }
}
