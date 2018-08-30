/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题
 *
 *		功能
 *
 *		日期 2018.6.22
*/

namespace Msg
{
    public class MsgUIManager : MsgManagerBase
    {
        #region 单例
        private static MsgUIManager _instance;
        private static readonly object _lockobj;
        static MsgUIManager()
        {
            _lockobj = new object();
        }
        private MsgUIManager() : base() { }
        public static MsgUIManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockobj)
                    {
                        if (_instance == null)
                            _instance = new MsgUIManager();
                    }
                }
                return _instance;
            }
        }
        #endregion


    }
}


