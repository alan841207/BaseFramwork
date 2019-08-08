using BaseFramwork.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramwork.IServices
{
    public interface IUserRoleServices:IBaseServices<UserRole>
    {
        Task<UserRole> SaveUserRole(int uid, int rid);
        Task<int> GetRoleIdByUid(int uid);
    }
}
