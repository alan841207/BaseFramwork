using SqlSugar;

namespace BaseFramwork.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class OperateLog
    {
        /// <summary>
        /// 
        /// </summary>
        public OperateLog()
        {
        }

        private System.Int32 _Id;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 Id { get { return this._Id; } set { this._Id = value; } }

        private System.Boolean? _IsDeleted;
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean? IsDeleted { get { return this._IsDeleted; } set { this._IsDeleted = value; } }

        private System.String _Area;
        /// <summary>
        /// 
        /// </summary>
        public System.String Area { get { return this._Area; } set { this._Area = value; } }

        private System.String _Controller;
        /// <summary>
        /// 
        /// </summary>
        public System.String Controller { get { return this._Controller; } set { this._Controller = value; } }

        private System.String _Action;
        /// <summary>
        /// 
        /// </summary>
        public System.String Action { get { return this._Action; } set { this._Action = value; } }

        private System.String _IPAddress;
        /// <summary>
        /// 
        /// </summary>
        public System.String IPAddress { get { return this._IPAddress; } set { this._IPAddress = value; } }

        private System.String _Description;
        /// <summary>
        /// 
        /// </summary>
        public System.String Description { get { return this._Description; } set { this._Description = value; } }

        private System.DateTime? _LogTime;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? LogTime { get { return this._LogTime; } set { this._LogTime = value; } }

        private System.String _LoginName;
        /// <summary>
        /// 
        /// </summary>
        public System.String LoginName { get { return this._LoginName; } set { this._LoginName = value; } }

        private System.Int32 _UserId;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 UserId { get { return this._UserId; } set { this._UserId = value; } }

        private System.Int32? _User_uID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? User_uID { get { return this._User_uID; } set { this._User_uID = value; } }
    }
}