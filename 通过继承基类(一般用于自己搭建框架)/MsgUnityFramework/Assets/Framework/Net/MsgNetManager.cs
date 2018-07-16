using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgNetManager : MsgManagerBase
{
    // 单例
    public static MsgNetManager Instance;
    private void Awake()
    {
        Instance = this;
    }



}
