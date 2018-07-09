using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgCharacterManager : MsgManagerBase
{

    public static MsgCharacterManager Instance;

    private void Awake()
    {
        Instance = this;
    }

}
