using SqlSugar;

namespace BaseFramwork.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class TopicDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public TopicDetail()
        {
        }

        private System.Int32 _Id;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 Id { get { return this._Id; } set { this._Id = value; } }

        private System.Int32 _TopicId;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 TopicId { get { return this._TopicId; } set { this._TopicId = value; } }

        private System.String _tdLogo;
        /// <summary>
        /// 
        /// </summary>
        public System.String tdLogo { get { return this._tdLogo; } set { this._tdLogo = value; } }

        private System.String _tdName;
        /// <summary>
        /// 
        /// </summary>
        public System.String tdName { get { return this._tdName; } set { this._tdName = value; } }

        private System.String _tdContent;
        /// <summary>
        /// 
        /// </summary>
        public System.String tdContent { get { return this._tdContent; } set { this._tdContent = value; } }

        private System.String _tdDetail;
        /// <summary>
        /// 
        /// </summary>
        public System.String tdDetail { get { return this._tdDetail; } set { this._tdDetail = value; } }

        private System.String _tdSectendDetail;
        /// <summary>
        /// 
        /// </summary>
        public System.String tdSectendDetail { get { return this._tdSectendDetail; } set { this._tdSectendDetail = value; } }

        private System.Boolean _tdIsDelete;
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean tdIsDelete { get { return this._tdIsDelete; } set { this._tdIsDelete = value; } }

        private System.Int32 _tdRead;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 tdRead { get { return this._tdRead; } set { this._tdRead = value; } }

        private System.Int32 _tdCommend;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 tdCommend { get { return this._tdCommend; } set { this._tdCommend = value; } }

        private System.Int32 _tdGood;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 tdGood { get { return this._tdGood; } set { this._tdGood = value; } }

        private System.DateTime _tdCreatetime;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime tdCreatetime { get { return this._tdCreatetime; } set { this._tdCreatetime = value; } }

        private System.DateTime _tdUpdatetime;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime tdUpdatetime { get { return this._tdUpdatetime; } set { this._tdUpdatetime = value; } }

        private System.Int32 _tdTop;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 tdTop { get { return this._tdTop; } set { this._tdTop = value; } }

        private System.String _tdAuthor;
        /// <summary>
        /// 
        /// </summary>
        public System.String tdAuthor { get { return this._tdAuthor; } set { this._tdAuthor = value; } }
    }
}