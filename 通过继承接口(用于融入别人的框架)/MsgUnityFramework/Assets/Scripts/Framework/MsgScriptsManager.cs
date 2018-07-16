/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题:用于加载脚本基类
 *
 *		功能： 需要设置 本脚本 在运行顺序的最前面
 *              
 *      使用方法：   将本脚本挂载的预设体实例化
 *      事件码：     在EventCode文件夹中，根据具体项目修改
 *      添加新功能： 添加新的事件码和对应的方法
 *      添加新模块： 添加新的模块码，以及对应的 Manager 类
 *      
 *		日期 2018.6.22
*/
using UnityEngine;
public class MsgScriptsManager : MonoBehaviour 
{
    // 添加新的 Manager，在这里添加
    void Awake()
	{
        DontDestroyOnLoad(this);
	    gameObject.AddComponent<MsgCenterManager>();

        gameObject.AddComponent<MsgUIManager>();
        gameObject.AddComponent<MsgAudioManager>();
        gameObject.AddComponent<MsgNetManager>();
	    gameObject.AddComponent<MsgGameManager>();
	    gameObject.AddComponent<MsgCharacterManager>();
	}
	
}
