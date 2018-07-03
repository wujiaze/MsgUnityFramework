using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetManager : ManagerBase
{
    // 单例
    public static NetManager Instance;
    private void Awake()
    {
        Instance = this;
    }



}
