using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgGameManager : MsgManagerBase
{

    public static MsgGameManager Instance;

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }

}
