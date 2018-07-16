using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgNetManager : MsgManagerBase
{
    // 单例
    public static MsgNetManager Instance;
    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }



}
