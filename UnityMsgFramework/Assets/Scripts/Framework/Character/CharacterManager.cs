using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : ManagerBase
{

    public static CharacterManager Instance;

    private void Awake()
    {
        Instance = this;
    }

}
