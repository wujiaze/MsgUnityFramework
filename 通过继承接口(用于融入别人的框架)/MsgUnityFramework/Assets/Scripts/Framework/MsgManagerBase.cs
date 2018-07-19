/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题: 每个模块的基类
 *
 *		功能：1、保存自身注册的一系列消息
 *
 *		日期 2018.6.22
*/

using System.Collections.Generic;
using Assets.Scripts.Framework;
using UnityEngine;

public class MsgManagerBase :MonoBehaviour
{
    /// <summary>
    /// 存储 消息的事件码 和 对应脚本 的字典
    ///     用于绑定，执行
    /// </summary>
    private Dictionary<int, List<IExecute>> _dictEventCodeBase;//  重点 每一个继承 MsgManagerBase 的脚本(即每一个Manager)都有一个自身的字典（即不同引用的字典）

    /// <summary>
    /// 存储 脚本 和 其对应的事件码 的字典
    ///     用于 解绑 
    /// </summary>

    private Dictionary<IExecute, List<int>> _dictBaseCodes;   // 每一个模块，一份字典

    protected virtual void Awake()
    {
        _dictEventCodeBase = new Dictionary<int, List<IExecute>>();
        _dictBaseCodes = new Dictionary<IExecute, List<int>>();
    }

    protected virtual void OnDestroy()
    {
        UnBindEvents(this as IExecute);
    }


    /// <summary>
    /// 注册事件码 和 对应的脚本
    ///        一个脚本关注多个事件
    ///     用于 各类 Base 重写
    /// </summary>
    /// <param name="eventCodes">消息的事件码集合</param>
    /// <param name="msgMonoBase">对应的脚本</param>
    public virtual void BindEvent(IExecute msgMonoBase,params int[] eventCodes)
    {
        if (eventCodes == null) return;
        if (msgMonoBase == null) return;
        foreach (int eventCode in eventCodes)
        {
            Add(eventCode, msgMonoBase);
        }
    }

    /// <summary>
    /// 解绑事件码
    /// </summary>
    public virtual void UnBindEvents(IExecute msgMonoBase)
    {
        if(msgMonoBase ==null)return;
        // 从字典2 获取 事件码 ，在字典1中删除
        if (!_dictBaseCodes.ContainsKey(msgMonoBase))
        {
            Debug.Log("该脚本没有在字典中");
            return;
        }
        else
        {
            Remove(msgMonoBase, _dictBaseCodes[msgMonoBase]);
        }
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="areaCode"></param>
    /// <param name="eventCode"></param>
    /// <param name="msgValue"></param>
    public virtual void Dispatch(int areaCode, int eventCode, object msgValue)
    {
        MsgCenterManager.Instance.Dispatch(areaCode, eventCode, msgValue);
    }

    /// <summary>
    /// 执行发来的消息
    ///     用于 各类 脚本 执行
    /// </summary>
    /// <param name="eventCode">事件码</param>
    /// <param name="msgValue">消息的参数</param>
    public virtual void Execute(int eventCode, object msgValue)
    {
        if (!_dictEventCodeBase.ContainsKey(eventCode))
        {
            Debug.LogWarning(GetType() + "/ 需要执行的消息码，没有注册过");
            return;
        }
        foreach (IExecute monoBase in _dictEventCodeBase[eventCode])
        {
            monoBase.Execute(eventCode, msgValue);
            // 当在执行中删除了事件码，防止Net框架再次执行一遍，出现错误
            if (!_dictEventCodeBase.ContainsKey(eventCode))
                break;
        }
    }


    /// <summary>
    /// 注册事件码 和 对应的脚本
    ///        一个脚本关注一个事件
    /// </summary>
    /// <param name="eventCode">消息的事件码</param>
    /// <param name="msgMonoBase">对应的脚本</param>
    private void Add(int eventCode, IExecute msgMonoBase)
    {
        // 字典1
        if (!_dictEventCodeBase.ContainsKey(eventCode))
        {
            // 没有对应的事件码
            List<IExecute> list = new List<IExecute>();
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
        // 字典2
        if (!_dictBaseCodes.ContainsKey(msgMonoBase))
        {
            List<int> list = new List<int>();
            list.Add(eventCode);
            _dictBaseCodes.Add(msgMonoBase, list);
        }
        else
        {
            if (!_dictBaseCodes[msgMonoBase].Contains(eventCode))
            {
                _dictBaseCodes[msgMonoBase].Add(eventCode);
            }
        }
    }


    /// <summary>
    /// 移除事件码 和 对应的脚本
    ///        一个脚本 对应 多个事件码
    /// </summary>
    /// <param name="eventCodes">消息的事件码集合</param>
    /// <param name="msgMonoBase">对应的脚本</param>
    private void Remove(IExecute msgMonoBase, List<int> eventCodes)
    {
        if (eventCodes == null) return;
        if (msgMonoBase == null) return;
        foreach (int eventCode in eventCodes)
        {
            Remove(eventCode, msgMonoBase);
        }
        //字典2中删除
        if (_dictBaseCodes.ContainsKey(msgMonoBase))
            _dictBaseCodes.Remove(msgMonoBase);
    }
    /// <summary>
    /// 移除事件码 和 对应的脚本
    ///         一个脚本 对应 一个事件码
    /// </summary>
    /// <param name="eventCode">消息的事件码</param>
    /// <param name="msgMonoBase">对应的脚本</param>
    private void Remove(int eventCode, IExecute msgMonoBase)
    {
        // 在字典1 中删除
        if (_dictEventCodeBase.ContainsKey(eventCode))
        {
            if (_dictEventCodeBase[eventCode].Contains(msgMonoBase))
            {
                _dictEventCodeBase[eventCode].Remove(msgMonoBase);
            }
            else
            {
                Debug.LogWarning(GetType() + " / Remove / " + "需要移除的脚本，没有注册过！");
            }
        }
        else
        {
            Debug.LogWarning(GetType() + " / Remove / " + "需要移除的事件码，没有注册过！");
        }
        // 事件码对应的脚本为0，则删除该事件码
        if (_dictEventCodeBase.ContainsKey(eventCode) && _dictEventCodeBase[eventCode].Count == 0)
        {
            _dictEventCodeBase.Remove(eventCode);
        }

    }


   

}
