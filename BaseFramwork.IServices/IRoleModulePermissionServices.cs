using BaseFramwork.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramwork.IServices
{
    /// <summary>
    /// RoleModulePermissionServices
    /// </summary>	
    public interface IRoleModulePermissionServices : IBaseServices<RoleModulePermission>
    {

        Task<List<RoleModulePermission>> GetRoleModule();
        Task<List<RoleModulePermission>> TestModelWithChildren();
    }
}
