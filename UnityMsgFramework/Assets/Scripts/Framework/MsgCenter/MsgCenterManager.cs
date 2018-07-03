/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题:消息处理中心
 *
 *		功能：负责消息的转发
 *
 *		日期 2018.6.22
*/
public class MsgCenterManager : ManagerBase
{
    public static MsgCenterManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    

    /// <summary>
    /// 发送消息
    ///     处理项目中所有的发送消息
    /// </summary>
    /// <param name="areaCode">消息的区域码</param>
    /// <param name="eventCode">消息的事件码</param>
    /// <param name="msgValue">消息的参数</param>
    public override void Dispatch(int areaCode,int eventCode,object msgValue)
    {
        switch (areaCode)
        {
            case AreaCode.AUDIO:
                AudioManager.Instance.Execute(eventCode, msgValue);
                break;
            case AreaCode.CHARACTER:
                CharacterManager.Instance.Execute(eventCode,msgValue);
                break;
            case AreaCode.GAME:
                GameMgr.Instance.Execute(eventCode, msgValue);
                break;
            case AreaCode.NET:
                NetManager.Instance.Execute(eventCode, msgValue);
                break;
            case AreaCode.UI:
                UIManager.Instance.Execute(eventCode, msgValue);
                break;
            // 添加新的模块 
            default:
                break;
        }
    }
}
