/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题 ： Domo
 *
 *		功能
 *
 *		日期 2018.6.22
*/
using UnityEngine;
using UnityEngine.UI;

public class TestPanel : MsgUIBase
{
    public Button Button;
    public Text Text;
    private void Awake()
    {
        Button.onClick.AddListener(OnClickHandle);
        // 绑定事件
        BindEvent(UIEventCode.UI_DEMO);
    }

    private void OnClickHandle()
    {
        Text.text += "1";
        Dispatch(AreaCode.AUDIO, AudioEventCode.AUDIO_DEMO, "1.mp3");
        Dispatch(AreaCode.UI, UIEventCode.UI_DEMO, "1.mp3");
        Dispatch(AreaCode.NET, NetEventCode.NET_DEMO, "1111");
    }

    public override void Execute(int eventCode, object msgValue)
    {
        switch (eventCode)
        {
            case UIEventCode.UI_DEMO:
                Debug.Log(GetType()+"/" + msgValue);
                break;
        }
    }
}
