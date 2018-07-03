﻿/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题:用于加载脚本基类
 *
 *		功能： 需要设置 本脚本 在运行顺序的最前面
 *              
 *      使用方法：将预设体实例化
 *
 *      添加新功能： 添加新的事件码和对应的方法
 *      添加新模块： 添加新的区域码/模块码，以及对应的 Base/Manager 类
 *      
 *		日期 2018.6.22
*/
using UnityEngine;
public class FrameworkManager : MonoBehaviour 
{
    // 添加新的 Manager，在这里添加
    void Awake()
	{
        DontDestroyOnLoad(this);
	    gameObject.AddComponent<MsgCenterManager>();
        gameObject.AddComponent<UIManager>();
        gameObject.AddComponent<AudioManager>();
        gameObject.AddComponent<NetManager>();
	    gameObject.AddComponent<GameMgr>();
	    gameObject.AddComponent<CharacterManager>();
	}
	
}