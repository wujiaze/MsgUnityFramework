/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题:声音模块管理
 *
 *		功能
 *
 *		日期 2018.6.22
*/
namespace Msg
{
    public class MsgAudioManager : MsgManagerBase
    {
        #region 单例
        private static MsgAudioManager _instance;
        private static readonly object _lockobj;
        static MsgAudioManager()
        {
            _lockobj = new object();
        }
        private MsgAudioManager() : base() { }
        public static MsgAudioManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockobj)
                    {
                        if (_instance == null)
                            _instance = new MsgAudioManager();
                    }
                }
                return _instance;
            }
        }
        #endregion

    }
}


