using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BaseFramwork.Common.Helper;
using BaseFramwork.Core.AuthHelper;
using BaseFramwork.Core.AuthHelper.OverWrite;
using BaseFramwork.Core.AuthHelper.Policys;
using BaseFramwork.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseFramwork.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly ISysUserInfoServices _sysUserInfoServices;
        readonly IUserRoleServices _userRoleServices;
        readonly IRoleServices _roleServices;
        readonly PermissionRequirement _requirement;
        public LoginController(ISysUserInfoServices sysUserInfoServices, IUserRoleServices userRoleServices, IRoleServices roleServices, PermissionRequirement requirement)
        {
            this._sysUserInfoServices = sysUserInfoServices;
            this._userRoleServices = userRoleServices;
            this._roleServices = roleServices;
            _requirement = requirement;
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("Token")]
        public async Task<object> GetJwtStr(string name,string pwd)
        {
            string JwtStr = string.Empty;
            bool suc = false;

            if (string.IsNullOrEmpty(name) || string .IsNullOrEmpty(pwd))
            {
                JwtStr = "Login Fail!!!";
            }

            var userRole = "Admin";

            if (userRole!=null)
            {
                TokenModelJwt tokenModelJwt = new TokenModelJwt { Uid=1, Role=userRole };
                //得到Token
                JwtStr =JwtHelper.IssueJwt(tokenModelJwt);
                suc = true;

            }

            return Ok(new{
                jwt = JwtStr,
                success = suc
            });

        }



        /// <summary>
        /// 获取JWT的方法3：整个系统主要方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("JWTToken3.0")]
        public async Task<object> GetJwtToken3(string name = "", string pass = "")
        {
            string jwtStr = string.Empty;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
            {
                return new JsonResult(new
                {
                    Status = false,
                    message = "用户名或密码不能为空"
                });
            }

            pass = MD5Helper.MD5Encrypt32(pass);

            var user = await _sysUserInfoServices.Query(d => d.uLoginName == name && d.uLoginPWD == pass);
            if (user.Count > 0)
            {
                var userRoles = await _sysUserInfoServices.GetUserRoleNameStr(name, pass);
                //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(JwtRegisteredClaimNames.Jti, user.FirstOrDefault().uID.ToString()),
                    new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(_requirement.Expiration.TotalSeconds).ToString()) };
                claims.AddRange(userRoles.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));

                //用户标识
                var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
                identity.AddClaims(claims);

                var token = JwtToken.BuildJwtToken(claims.ToArray(), _requirement);
                return new JsonResult(token);
            }
            else
            {
                return new JsonResult(new
                {
                    success = false,
                    message = "认证失败"
                });
            }



        }
    }
}