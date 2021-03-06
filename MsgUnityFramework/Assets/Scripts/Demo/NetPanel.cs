﻿
using Msg;
using UnityEngine;

class NetPanel:MonoBehaviour,IExecute
{
    // 字段
    private void Awake()
    {
        MsgNetManager.Instance.BindEvent(this,NetEventCode.NET_DEMO); // 绑定事件码，就要监听这个事件码
    }

    private void OnDestroy()
    {
        MsgNetManager.Instance.UnBindEvents(this);
    }

    public  void Execute(int eventCode, object msgValue)
    {
        switch (eventCode)
        {
            case NetEventCode.NET_DEMO:
                // 设计方法处理消息
                gameObject.SetActive(true);
                MsgNetManager.Instance.UnBindEvents(this);
                Progress(msgValue);
                break;
            default:
                break;
        }
    }

    private void Progress(object msgValue)
    {
        print(GetType() + " / 消息： " + msgValue);
    }
    // 测试
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            MsgNetManager.Instance.Dispatch(AreaCode.UI, UIEventCode.UI_DEMO, "发给ui的消息");  // 发送消息
        }
    }
}
