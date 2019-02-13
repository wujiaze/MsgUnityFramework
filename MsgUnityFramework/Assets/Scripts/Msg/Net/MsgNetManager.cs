namespace Msg
{
    public class MsgNetManager : MsgManagerBase
    {
        #region 单例
        private static MsgNetManager _instance;
        private static readonly object _lockobj;
        static MsgNetManager()
        {
            _lockobj = new object();
        }
        private MsgNetManager() : base() { }
        public static MsgNetManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockobj)
                    {
                        if (_instance == null)
                            _instance = new MsgNetManager();
                    }
                }
                return _instance;
            }
        }
        #endregion



    }
}


