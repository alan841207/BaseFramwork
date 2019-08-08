using SqlSugar;

namespace BaseFramwork.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class PasswordLib
    {
        /// <summary>
        /// 
        /// </summary>
        public PasswordLib()
        {
        }

        private System.Int32 _PLID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 PLID { get { return this._PLID; } set { this._PLID = value; } }

        private System.Boolean? _IsDeleted;
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean? IsDeleted { get { return this._IsDeleted; } set { this._IsDeleted = value; } }

        private System.String _plURL;
        /// <summary>
        /// 
        /// </summary>
        public System.String plURL { get { return this._plURL; } set { this._plURL = value; } }

        private System.String _plPWD;
        /// <summary>
        /// 
        /// </summary>
        public System.String plPWD { get { return this._plPWD; } set { this._plPWD = value; } }

        private System.String _plAccountName;
        /// <summary>
        /// 
        /// </summary>
        public System.String plAccountName { get { return this._plAccountName; } set { this._plAccountName = value; } }

        private System.Int32? _plStatus;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? plStatus { get { return this._plStatus; } set { this._plStatus = value; } }

        private System.Int32? _plErrorCount;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? plErrorCount { get { return this._plErrorCount; } set { this._plErrorCount = value; } }

        private System.String _plHintPwd;
        /// <summary>
        /// 
        /// </summary>
        public System.String plHintPwd { get { return this._plHintPwd; } set { this._plHintPwd = value; } }

        private System.String _plHintquestion;
        /// <summary>
        /// 
        /// </summary>
        public System.String plHintquestion { get { return this._plHintquestion; } set { this._plHintquestion = value; } }

        private System.DateTime? _plCreateTime;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? plCreateTime { get { return this._plCreateTime; } set { this._plCreateTime = value; } }

        private System.DateTime? _plUpdateTime;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? plUpdateTime { get { return this._plUpdateTime; } set { this._plUpdateTime = value; } }

        private System.DateTime? _plLastErrTime;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? plLastErrTime { get { return this._plLastErrTime; } set { this._plLastErrTime = value; } }

        private System.String _test;
        /// <summary>
        /// 
        /// </summary>
        public System.String test { get { return this._test; } set { this._test = value; } }
    }
}