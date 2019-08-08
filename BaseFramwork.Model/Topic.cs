using SqlSugar;

namespace BaseFramwork.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Topic
    {
        /// <summary>
        /// 
        /// </summary>
        public Topic()
        {
        }

        private System.Int32 _Id;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 Id { get { return this._Id; } set { this._Id = value; } }

        private System.String _tLogo;
        /// <summary>
        /// 
        /// </summary>
        public System.String tLogo { get { return this._tLogo; } set { this._tLogo = value; } }

        private System.String _tName;
        /// <summary>
        /// 
        /// </summary>
        public System.String tName { get { return this._tName; } set { this._tName = value; } }

        private System.String _tDetail;
        /// <summary>
        /// 
        /// </summary>
        public System.String tDetail { get { return this._tDetail; } set { this._tDetail = value; } }

        private System.String _tSectendDetail;
        /// <summary>
        /// 
        /// </summary>
        public System.String tSectendDetail { get { return this._tSectendDetail; } set { this._tSectendDetail = value; } }

        private System.Boolean _tIsDelete;
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean tIsDelete { get { return this._tIsDelete; } set { this._tIsDelete = value; } }

        private System.Int32 _tRead;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 tRead { get { return this._tRead; } set { this._tRead = value; } }

        private System.Int32 _tCommend;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 tCommend { get { return this._tCommend; } set { this._tCommend = value; } }

        private System.Int32 _tGood;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 tGood { get { return this._tGood; } set { this._tGood = value; } }

        private System.DateTime _tCreatetime;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime tCreatetime { get { return this._tCreatetime; } set { this._tCreatetime = value; } }

        private System.DateTime _tUpdatetime;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime tUpdatetime { get { return this._tUpdatetime; } set { this._tUpdatetime = value; } }

        private System.String _tAuthor;
        /// <summary>
        /// 
        /// </summary>
        public System.String tAuthor { get { return this._tAuthor; } set { this._tAuthor = value; } }
    }
}