/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题
 *
 *		功能
 *
 *		日期 2018.6.22
*/

using Assets.Scripts.Framework;
public class MsgUIManager : MsgManagerBase
{
    public static MsgUIManager Instance = null;
    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }


}
