/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题:视频模块管理
 *
 *		功能
 *
 *		日期 2019.3.28
*/

namespace Msg
{
    public class MsgVideoManager : MsgManagerBase
    {
        #region 单例
        private static MsgVideoManager _instance;
        private static readonly object _lockobj;
        static MsgVideoManager()
        {
            _lockobj = new object();
        }
        private MsgVideoManager() : base() { }
        public static MsgVideoManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockobj)
                    {
                        if (_instance == null)
                            _instance = new MsgVideoManager();
                    }
                }
                return _instance;
            }
        }
        #endregion


    }
}
