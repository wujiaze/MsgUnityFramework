/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题 : Audio 对象的基类
 *
 *		功能
 *
 *		日期 2018.6.22
*/

using System.Collections.Generic;
public class MsgAudioBase : MsgMonoBase
{
    /// <summary>
    /// 绑定事件码
    /// </summary>
    /// <param name="eventCodes">事件码</param>
    protected override void BindEvent(params int[] eventCodes)
    {
        base.BindEvent(eventCodes);
        MsgAudioManager.Instance.Add(eventCodes, this);
    }
    /// <summary>
    /// 解绑事件码
    /// </summary>
    protected override void UnBindEvent()
    {
        UnBind(MsgAudioManager.Instance, this);
    }
}
