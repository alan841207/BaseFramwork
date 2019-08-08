using SqlSugar;

namespace BaseFramwork.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ModulePermission
    {
        /// <summary>
        /// 
        /// </summary>
        public ModulePermission()
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

        private System.Int32 _ModuleId;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ModuleId { get { return this._ModuleId; } set { this._ModuleId = value; } }

        private System.Int32 _PermissionId;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 PermissionId { get { return this._PermissionId; } set { this._PermissionId = value; } }

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