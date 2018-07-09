using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MsgUIBase {

	// Use this for initialization
	void Start () {
	    BindEvent(UIEventCode.UI_DEMO,UIEventCode.UI_DEMO);
    }
	
	// Update is called once per frame
	void Update () {
	    
    }

    public override void Execute(int eventCode, object msgValue)
    {
        switch (eventCode)
        {
            case UIEventCode.UI_DEMO:
                print(GetType() +"/"+msgValue);
                break;
        }
    }
}
