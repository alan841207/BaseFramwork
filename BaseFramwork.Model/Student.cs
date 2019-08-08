using SqlSugar;

namespace BaseFramwork.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Student
    {
        /// <summary>
        /// 
        /// </summary>
        public Student()
        {
        }

        private System.Int64 _Tid;
        /// <summary>
        /// 
        /// </summary>
        public System.Int64 Tid { get { return this._Tid; } set { this._Tid = value; } }

        private System.Int64? _ClassId;
        /// <summary>
        /// 
        /// </summary>
        public System.Int64? ClassId { get { return this._ClassId; } set { this._ClassId = value; } }

        private System.String _Name;
        /// <summary>
        /// 
        /// </summary>
        public System.String Name { get { return this._Name; } set { this._Name = value; } }
    }
}