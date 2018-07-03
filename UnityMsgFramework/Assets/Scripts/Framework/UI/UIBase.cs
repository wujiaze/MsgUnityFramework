/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题 : UI 对象的基类
 *
 *		功能
 *
 *		日期 2018.6.22
*/

public class UIBase : MonoBase 
{

    /// <summary>
    /// 绑定事件码
    /// </summary>
    /// <param name="eventCodes">事件码</param>
    protected override void BindEvent(params int[] eventCodes)
    {
        base.BindEvent(eventCodes);
        UIManager.Instance.Add(eventCodes, this);
    }
    /// <summary>
    /// 解绑事件码
    /// </summary>
    protected override void UnBindEvent()
    {
        UnBind(UIManager.Instance, this);
    }
}
