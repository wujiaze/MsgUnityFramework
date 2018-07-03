

using System;
using System.Collections.Generic;
using UnityEngine;

public class NetBase : MonoBase
{
    /// <summary>
    /// 绑定事件码
    /// </summary>
    /// <param name="eventCodes">事件码</param>
    protected override void BindEvent(params int[] eventCodes)
    {
        base.BindEvent(eventCodes);
        NetManager.Instance.Add(eventCodes, this);
    }
    /// <summary>
    /// 解绑事件码
    /// </summary>
    protected override void UnBindEvent()
    {
        UnBind(NetManager.Instance, this);
    }

}
