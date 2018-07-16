/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题
 *
 *		功能
 *
 *		日期 2018.6.22
*/

using Assets.Scripts.Framework;
using UnityEngine;
public class AudioPanel:MonoBehaviour,IExecute
{

    private void Awake()
    {
        MsgAudioManager.Instance.BindEvent(this,AudioEventCode.AUDIO_DEMO);
    }

    private void OnDestroy()
    {
        MsgAudioManager.Instance.UnBindEvents(this);
    }

    public void Execute(int eventCode, object msgValue)
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
