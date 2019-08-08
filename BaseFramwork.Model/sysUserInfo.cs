using SqlSugar;
using System;

namespace BaseFramwork.Model
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    public class sysUserInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public sysUserInfo()
        {
        }


        public sysUserInfo(string loginName, string loginPWD)
        {
            uLoginName = loginName;
            uLoginPWD = loginPWD;
            uRealName = uLoginName;
            uStatus = 0;
            uCreateTime = DateTime.Now;
            uUpdateTime = DateTime.Now;
            uLastErrTime = DateTime.Now;
            uErrorCount = 0;
            name = "";

        }

        private System.Int32 _uID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 uID { get { return this._uID; } set { this._uID = value; } }

        private System.String _uLoginName;
        /// <summary>
        /// 
        /// </summary>
        public System.String uLoginName { get { return this._uLoginName; } set { this._uLoginName = value; } }

        private System.String _uLoginPWD;
        /// <summary>
        /// 
        /// </summary>
        public System.String uLoginPWD { get { return this._uLoginPWD; } set { this._uLoginPWD = value; } }

        private System.String _uRealName;
        /// <summary>
        /// 
        /// </summary>
        public System.String uRealName { get { return this._uRealName; } set { this._uRealName = value; } }

        private System.Int32 _uStatus;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 uStatus { get { return this._uStatus; } set { this._uStatus = value; } }

        private System.String _uRemark;
        /// <summary>
        /// 
        /// </summary>
        public System.String uRemark { get { return this._uRemark; } set { this._uRemark = value; } }

        private System.DateTime _uCreateTime;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime uCreateTime { get { return this._uCreateTime; } set { this._uCreateTime = value; } }

        private System.DateTime _uUpdateTime;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime uUpdateTime { get { return this._uUpdateTime; } set { this._uUpdateTime = value; } }

        private System.DateTime _uLastErrTime;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime uLastErrTime { get { return this._uLastErrTime; } set { this._uLastErrTime = value; } }

        private System.Int32 _uErrorCount;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 uErrorCount { get { return this._uErrorCount; } set { this._uErrorCount = value; } }

        private System.String _name;
        /// <summary>
        /// 
        /// </summary>
        public System.String name { get { return this._name; } set { this._name = value; } }

        private System.Int32? _sex;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? sex { get { return this._sex; } set { this._sex = value; } }

        private System.Int32? _age;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? age { get { return this._age; } set { this._age = value; } }

        private System.DateTime? _birth;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? birth { get { return this._birth; } set { this._birth = value; } }

        private System.String _addr;
        /// <summary>
        /// 
        /// </summary>
        public System.String addr { get { return this._addr; } set { this._addr = value; } }

        private System.Boolean? _tdIsDelete;
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean? tdIsDelete { get { return this._tdIsDelete; } set { this._tdIsDelete = value; } }
    }
}