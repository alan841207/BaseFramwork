using BaseFramwork.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramwork.IRepository
{
    public interface IRoleModulePermissionRepository:IBaseRepository<RoleModulePermission>
    {
        Task<List<RoleModulePermission>> WithChildrenModel();
    }
}
