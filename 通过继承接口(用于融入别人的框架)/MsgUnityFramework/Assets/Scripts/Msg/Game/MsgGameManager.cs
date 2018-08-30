
namespace Msg
{
    public class MsgGameManager : MsgManagerBase
    {

        #region 单例
        private static MsgGameManager _instance;
        private static readonly object _lockobj;
        static MsgGameManager()
        {
            _lockobj = new object();
        }
        private MsgGameManager() : base() { }
        public static MsgGameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockobj)
                    {
                        if (_instance == null)
                            _instance = new MsgGameManager();
                    }
                }
                return _instance;
            }
        }
        #endregion


    }
}

