using BaseFramwork.Common.Helper;
using BaseFramwork.IRepository;
using BaseFramwork.IServices;
using BaseFramwork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SysUserInfoServices : BaseServices<sysUserInfo>, ISysUserInfoServices
    {
        ISysUserInfoRepository _dal;
        IUserRoleServices _userRoleServices;
        IRoleRepository _roleRepository;
        public SysUserInfoServices(ISysUserInfoRepository dal, IUserRoleServices userRoleServices, IRoleRepository roleRepository)
        {
            this._dal = dal;
            this._userRoleServices = userRoleServices;
            this._roleRepository = roleRepository;
            base.baseDal = dal;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="loginPwd"></param>
        /// <returns></returns>
        public async Task<sysUserInfo> SaveUserInfo(string loginName, string loginPwd)
        {
            sysUserInfo sysUserInfo = new sysUserInfo(loginName, loginPwd);
            sysUserInfo model = new sysUserInfo();
            var userList = await base.Query(a => a.uLoginName == sysUserInfo.uLoginName && a.uLoginPWD == sysUserInfo.uLoginPWD);
            if (userList.Count > 0)
            {
                model = userList.FirstOrDefault();
            }
            else
            {
                var id = await base.Add(sysUserInfo);
                model = await base.QueryByID(id);
            }

            return model;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="loginPwd"></param>
        /// <returns></returns>
        public async Task<string> GetUserRoleNameStr(string loginName, string loginPwd)
        {
            string roleName = "";
            var user = (await base.Query(a => a.uLoginName == loginName && a.uLoginPWD == loginPwd)).FirstOrDefault();
            if (user != null)
            {
                var userRoles = await _userRoleServices.Query(ur => ur.UserId == user.uID);
                if (userRoles.Count > 0)
                {
                    var roles = await _roleRepository.QueryByIDs(userRoles.Select(ur => ur.RoleId.ObjToString()).ToArray());

                    roleName = string.Join(',', roles.Select(r => r.Name).ToArray());
                }
            }
            return roleName;
        }
    }
}
