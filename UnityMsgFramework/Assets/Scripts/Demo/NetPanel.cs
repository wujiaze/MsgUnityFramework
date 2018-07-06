

using UnityEngine;

class NetPanel:NetBase
{
    // 字段
    private void Awake()
    {
        BindEvent(NetEventCode.NET_DEMO); // 绑定事件码，就要监听这个事件码
    }

    public override void Execute(int eventCode, object msgValue)
    {
        switch (eventCode)
        {
            case NetEventCode.NET_DEMO:
                // 设计方法处理消息
                UnBindEvent();
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
            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Dispatch(AreaCode.UI, UIEventCode.UI_DEMO, "发给ui的消息");  // 发送消息
        }
    }
}
