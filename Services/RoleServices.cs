﻿using BaseFramwork.Common;
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
    public class RoleServices:BaseServices<Role>,IRoleServices
    {
        IRoleRepository _dal;
        public RoleServices(IRoleRepository dal)
        {
            this._dal = dal;
            base.baseDal = dal;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public async Task<Role> SaveRole(string roleName)
        {
            Role role = new Role(roleName);
            Role model = new Role();
            var userList = await base.Query(a => a.Name == role.Name && a.Enabled);
            if (userList.Count > 0)
            {
                model = userList.FirstOrDefault();
            }
            else
            {
                var id = await base.Add(role);
                model = await base.QueryByID(id);
            }

            return model;

        }

        [Caching(AbsoluteExpiration = 30)]
        public async Task<string> GetRoleNameByRid(int rid)
        {
            return ((await base.QueryByID(rid))?.Name);
        }
    }
}
