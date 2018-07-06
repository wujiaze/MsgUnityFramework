/*	
 *	 Title : 基于消息机制的Unity框架
 *
 * 		主题：模块的基类
 *
 *		功能：扩展 MonoBehaviour 的功能
 *
 *		日期 2018.6.22
*/

using System;
using System.Collections.Generic;
using UnityEngine;
public class MonoBase : MonoBehaviour
{
    /// <summary>
    /// 监听的事件码集合
    ///     主要用于解绑事件码
    /// </summary>
    private List<int> _eventCodeList = new List<int>();

    /// <summary>
    /// 绑定事件码
    ///     各类Base重写，各类脚本执行
    /// </summary>
    /// <param name="eventCodes">事件码</param>
    protected virtual void BindEvent(params int[] eventCodes)
    {
        foreach (int eventCode in eventCodes)
        {
            if(_eventCodeList.Contains(eventCode))
                continue;
            _eventCodeList.Add(eventCode);
        }
    }

    /// <summary>
    /// 解绑事件码
    ///     各类Base重写，各类脚本执行
    /// </summary>
    protected virtual void UnBindEvent()
    {

    }

    /// <summary>
    /// 解绑
    /// </summary>
    /// <param name="manager">区域管理者</param>
    /// <param name="monoBase">脚本对象</param>
    protected virtual void UnBind(ManagerBase manager, MonoBase monoBase)
    {
        if (_eventCodeList.Count == 0) 
            throw new Exception(GetType() + "/UnBind()" + "要解除事件码的脚本，没有绑定的事件码"+ Environment.NewLine+ "如果在程序结束出现，则不必理会");
        manager.Remove(_eventCodeList.ToArray(),monoBase);
        this._eventCodeList.Clear();
    }



    /// <summary>
    /// 执行发来的消息
    ///     ManagerBase 重写 ，各类脚本执行
    /// </summary>
    /// <param name="eventCode">事件码</param>
    /// <param name="msgValue">消息的参数</param>
    public virtual void Execute(int eventCode, object msgValue)
    {

    }



    /// <summary>
    ///  发送消息
    ///     各类脚本执行
    /// </summary>
    /// <param name="areaCode">接受对象的模块码/区域码</param>
    /// <param name="eventCode">事件码</param>
    /// <param name="msgValue">消息参数</param>
    public virtual void Dispatch(int areaCode, int eventCode, object msgValue)
    {
        MsgCenterManager.Instance.Dispatch(areaCode, eventCode, msgValue);
    }


    /// <summary>
    /// 销毁脚本时，解绑事件码
    ///       解绑消息，脚本就不需要重写，其他需求就在脚本中重写
    /// </summary>
    protected virtual void OnDestroy()
    {
        this.UnBindEvent(); // 会执行具体脚本的 OnDestroy 方法，从而执行对应的 UnBindEvent 方法
    }


}
