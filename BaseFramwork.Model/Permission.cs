using SqlSugar;

namespace BaseFramwork.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// 
        /// </summary>
        public Permission()
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

        private System.String _Code;
        /// <summary>
        /// 
        /// </summary>
        public System.String Code { get { return this._Code; } set { this._Code = value; } }

        private System.String _Name;
        /// <summary>
        /// 
        /// </summary>
        public System.String Name { get { return this._Name; } set { this._Name = value; } }

        private System.Int32 _OrderSort;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 OrderSort { get { return this._OrderSort; } set { this._OrderSort = value; } }

        private System.Int32? _Mid;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? Mid { get { return this._Mid; } set { this._Mid = value; } }

        private System.Int32? _Pid;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? Pid { get { return this._Pid; } set { this._Pid = value; } }

        private System.Boolean? _IsButton;
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean? IsButton { get { return this._IsButton; } set { this._IsButton = value; } }

        private System.String _Icon;
        /// <summary>
        /// 
        /// </summary>
        public System.String Icon { get { return this._Icon; } set { this._Icon = value; } }

        private System.String _Description;
        /// <summary>
        /// 
        /// </summary>
        public System.String Description { get { return this._Description; } set { this._Description = value; } }

        private System.Boolean _Enabled;
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean Enabled { get { return this._Enabled; } set { this._Enabled = value; } }

        private System.Int32? _CreateId;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? CreateId { get { return this._CreateId; } set { this._CreateId = value; } }

        private System.String _CreateBy;
        /// <summary>
        /// 
        /// </summary>
        public System.String CreateBy { get { return this._CreateBy; } set { this._CreateBy = value; } }

        private System.DateTime? _CreateTime;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? CreateTime { get { return this._CreateTime; } set { this._CreateTime = value; } }

        private System.Int32? _ModifyId;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? ModifyId { get { return this._ModifyId; } set { this._ModifyId = value; } }

        private System.String _ModifyBy;
        /// <summary>
        /// 
        /// </summary>
        public System.String ModifyBy { get { return this._ModifyBy; } set { this._ModifyBy = value; } }

        private System.DateTime? _ModifyTime;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? ModifyTime { get { return this._ModifyTime; } set { this._ModifyTime = value; } }
    }
}