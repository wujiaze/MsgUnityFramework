/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题: 每个模块的基类
 *
 *		功能：1、保存自身注册的一系列消息
 *
 *		日期 2018.6.22
*/

using System.Collections.Generic;
using UnityEngine;

public class MsgManagerBase : MsgMonoBase
{
    /// <summary>
    /// 存储 消息的事件码 和 对应脚本 的字典
    /// </summary>
    private Dictionary<int, List<MsgMonoBase>> _dictEventCodeBase = new Dictionary<int, List<MsgMonoBase>>();//  重点 每一个继承 MsgManagerBase 的脚本(即每一个Manager)都有一个自身的字典（即不同引用的字典）


    /// <summary>
    /// 注册事件码 和 对应的脚本
    ///        一个脚本关注多个事件
    ///     用于 各类 Base 重写
    /// </summary>
    /// <param name="eventCodes">消息的事件码集合</param>
    /// <param name="msgMonoBase">对应的脚本</param>
    public void Add(int[] eventCodes, MsgMonoBase msgMonoBase)
    {
        if (eventCodes == null) return;
        if (msgMonoBase == null) return;
        foreach (int eventCode in eventCodes)
        {
            Add(eventCode, msgMonoBase);
        }
    }
    /// <summary>
    /// 注册事件码 和 对应的脚本
    ///        一个脚本关注一个事件
    /// </summary>
    /// <param name="eventCode">消息的事件码</param>
    /// <param name="msgMonoBase">对应的脚本</param>
    private void Add(int eventCode, MsgMonoBase msgMonoBase)
    {
        if (!_dictEventCodeBase.ContainsKey(eventCode))
        {
            // 没有对应的事件码
            List<MsgMonoBase> list = new List<MsgMonoBase>();
            list.Add(msgMonoBase);
            _dictEventCodeBase.Add(eventCode, list);
        }
        else
        {
            if (!_dictEventCodeBase[eventCode].Contains(msgMonoBase))
            {
                _dictEventCodeBase[eventCode].Add(msgMonoBase);
            }
        }
    }


    /// <summary>
    /// 移除事件码 和 对应的脚本
    ///        一个脚本 对应 多个事件码
    /// </summary>
    /// <param name="eventCodes">消息的事件码集合</param>
    /// <param name="msgMonoBase">对应的脚本</param>
    public void Remove(int[] eventCodes, MsgMonoBase msgMonoBase)
    {
        if (eventCodes == null) return;
        if (msgMonoBase == null) return;
        foreach (int eventCode in eventCodes)
        {
            Remove(eventCode, msgMonoBase);
        }
    }
    /// <summary>
    /// 移除事件码 和 对应的脚本
    ///         一个脚本 对应 一个事件码
    /// </summary>
    /// <param name="eventCode">消息的事件码</param>
    /// <param name="msgMonoBase">对应的脚本</param>
    private void Remove(int eventCode, MsgMonoBase msgMonoBase)
    {
        if (_dictEventCodeBase.ContainsKey(eventCode))
        {
            if (_dictEventCodeBase[eventCode].Contains(msgMonoBase))
            {
                _dictEventCodeBase[eventCode].Remove(msgMonoBase);
            }
            else
            {
                Debug.LogWarning("需要移除的脚本，没有注册过！");
            }
        }
        else
        {
            Debug.LogWarning("需要移除的事件码，没有注册过！");
        }
        // 事件码对应的脚本为0，则删除该事件码
        if (_dictEventCodeBase.ContainsKey(eventCode) && _dictEventCodeBase[eventCode].Count == 0)
        {
            _dictEventCodeBase.Remove(eventCode);
        }

    }




    /// <summary>
    /// 执行发来的消息
    ///     用于 各类 脚本 执行
    /// </summary>
    /// <param name="eventCode">事件码</param>
    /// <param name="msgValue">消息的参数</param>
    public override void Execute(int eventCode, object msgValue)
    {
        if (!_dictEventCodeBase.ContainsKey(eventCode))
        {
            Debug.LogWarning(GetType() + "/ 需要执行的消息码，没有注册过");
            return;
        }
        foreach (MsgMonoBase monoBase in _dictEventCodeBase[eventCode])
        {
            monoBase.Execute(eventCode, msgValue);
            // 当在执行中删除了事件码，防止Net框架再次执行一遍
            if(!_dictEventCodeBase.ContainsKey(eventCode))
                break;
        }
    }

}
