

namespace Msg
{
    public class MsgCharacterManager : MsgManagerBase
    {

        #region 单例
        private static MsgCharacterManager _instance;
        private static readonly object _lockobj;
        static MsgCharacterManager()
        {
            _lockobj = new object();
        }
        private MsgCharacterManager() : base() { }
        public static MsgCharacterManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockobj)
                    {
                        if (_instance == null)
                            _instance = new MsgCharacterManager();
                    }
                }
                return _instance;
            }
        }
        #endregion
    }
}


