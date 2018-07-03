/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题
 *
 *		功能
 *
 *		日期 2018.6.22
*/
using UnityEngine;
public class AudioPanel : AudioBase 
{

    private void Awake()
    {
        BindEvent(AudioEventCode.AUDIO_DEMO);
    }

    public override void Execute(int eventCode, object msgValue)
    {
        switch (eventCode)
        {
            case AudioEventCode.AUDIO_DEMO:
                Debug.Log("播放声音："+msgValue);
                break;
                default:
                break;
        }
    }

}
