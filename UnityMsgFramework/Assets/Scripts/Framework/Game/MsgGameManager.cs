using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgGameManager : MsgManagerBase
{

    public static MsgGameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

}
