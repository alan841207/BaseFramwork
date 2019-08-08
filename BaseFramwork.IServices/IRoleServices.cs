using BaseFramwork.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramwork.IServices
{
    public interface IRoleServices:IBaseServices<Role>
    {
        Task<Role> SaveRole(string roleName);
        Task<string> GetRoleNameByRid(int rid);
    }
}
