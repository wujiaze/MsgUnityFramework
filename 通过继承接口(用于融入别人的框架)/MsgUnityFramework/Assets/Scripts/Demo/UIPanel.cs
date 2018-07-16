using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Framework;
using UnityEngine;

public class UIPanel : MonoBehaviour,IExecute
{

	void Start () {
	    MsgUIManager.Instance.BindEvent(this,UIEventCode.UI_DEMO);
    }

    private void OnDestroy()
    {
        MsgUIManager.Instance.UnBindEvents(this);
    }


    public void Execute(int eventCode, object msgValue)
    {
        switch (eventCode)
        {
            case UIEventCode.UI_DEMO:
                Debug.Log(GetType() +"/"+msgValue);
                break;
        }
    }

}
