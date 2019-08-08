using BaseFramwork.IRepository;
using BaseFramwork.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoleModulePermissionRepository:BaseRepository<RoleModulePermission>,IRoleModulePermissionRepository
    {
        public async Task<List<RoleModulePermission>> WithChildrenModel()
        {
            var list = await Task.Run(() => Db.Queryable<RoleModulePermission>()
                    .Mapper(it => it.Role, it => it.RoleId)
                    .Mapper(it => it.Permission, it => it.PermissionId)
                    .Mapper(it => it.Module, it => it.ModuleId).ToList());

            return null;
        }
    }
}
