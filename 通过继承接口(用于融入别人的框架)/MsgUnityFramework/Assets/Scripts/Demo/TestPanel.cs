/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题 ： Domo
 *
 *		功能
 *
 *		日期 2018.6.22
*/

using Assets.Scripts.Framework;
using UnityEngine;
using UnityEngine.UI;

public class TestPanel : MonoBehaviour,IExecute
{
    public Button Button;
    public Text Text;
    private void Awake()
    {
        Button.onClick.AddListener(OnClickHandle);
        // 绑定事件
        MsgUIManager.Instance.BindEvent(this,UIEventCode.UI_DEMO);
    }

    private void OnDestroy()
    {
        MsgUIManager.Instance.UnBindEvents(this);
    }

    private void OnClickHandle()
    {
        Text.text += "1";
        MsgUIManager.Instance.Dispatch(AreaCode.AUDIO, AudioEventCode.AUDIO_DEMO, "1.mp3");
        MsgUIManager.Instance.Dispatch(AreaCode.UI, UIEventCode.UI_DEMO, "1.mp3");
        MsgUIManager.Instance.Dispatch(AreaCode.NET, NetEventCode.NET_DEMO, "1111");
    }

    public  void Execute(int eventCode, object msgValue)
    {
        switch (eventCode)
        {
            case UIEventCode.UI_DEMO:
                Debug.Log(GetType()+"/" + msgValue);
                break;
        }
    }
}
