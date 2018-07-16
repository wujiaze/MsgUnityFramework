using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgCharacterManager : MsgManagerBase
{

    public static MsgCharacterManager Instance;

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }

}
