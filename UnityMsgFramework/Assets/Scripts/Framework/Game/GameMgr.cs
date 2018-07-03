using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : ManagerBase
{

    public static GameMgr Instance;

    private void Awake()
    {
        Instance = this;
    }

}
