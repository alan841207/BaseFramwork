using SqlSugar;
using System;

namespace BaseFramwork.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Role
    {
        /// <summary>
        /// 
        /// </summary>
        public Role()
        {
            OrderSort = 1;
            CreateTime = DateTime.Now;
            ModifyTime = DateTime.Now;
            IsDeleted = false;
        }
        public Role(string name)
        {
            Name = name;
            Description = "";
            OrderSort = 1;
            Enabled = true;
            CreateTime = DateTime.Now;
            ModifyTime = DateTime.Now;

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

        private System.String _Name;
        /// <summary>
        /// 
        /// </summary>
        public System.String Name { get { return this._Name; } set { this._Name = value; } }

        private System.String _Description;
        /// <summary>
        /// 
        /// </summary>
        public System.String Description { get { return this._Description; } set { this._Description = value; } }

        private System.Int32 _OrderSort;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 OrderSort { get { return this._OrderSort; } set { this._OrderSort = value; } }

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