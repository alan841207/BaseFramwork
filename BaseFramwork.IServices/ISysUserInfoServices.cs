using BaseFramwork.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramwork.IServices
{
    public interface ISysUserInfoServices:IBaseServices<sysUserInfo>
    {
        Task<sysUserInfo> SaveUserInfo(string loginName, string loginPwd);
        Task<string> GetUserRoleNameStr(string loginName, string loginPwd);
    }
}
