using SqlSugar;

namespace BaseFramwork.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Guestbook
    {
        /// <summary>
        /// 
        /// </summary>
        public Guestbook()
        {
        }

        private System.Int32 _id;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 id { get { return this._id; } set { this._id = value; } }

        private System.Int32 _blogId;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 blogId { get { return this._blogId; } set { this._blogId = value; } }

        private System.DateTime _createdate;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime createdate { get { return this._createdate; } set { this._createdate = value; } }

        private System.String _username;
        /// <summary>
        /// 
        /// </summary>
        public System.String username { get { return this._username; } set { this._username = value; } }

        private System.String _phone;
        /// <summary>
        /// 
        /// </summary>
        public System.String phone { get { return this._phone; } set { this._phone = value; } }

        private System.String _QQ;
        /// <summary>
        /// 
        /// </summary>
        public System.String QQ { get { return this._QQ; } set { this._QQ = value; } }

        private System.String _body;
        /// <summary>
        /// 
        /// </summary>
        public System.String body { get { return this._body; } set { this._body = value; } }

        private System.String _ip;
        /// <summary>
        /// 
        /// </summary>
        public System.String ip { get { return this._ip; } set { this._ip = value; } }

        private System.Boolean _isshow;
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean isshow { get { return this._isshow; } set { this._isshow = value; } }
    }
}