using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MiniGameController
{
    public static void PlayMiniGame(GameObject miniGameObject) 
    {
        var name = miniGameObject.name;
        var scriptType = Type.GetType(name+"Controller");
        var script = miniGameObject.GetComponent(scriptType);
        if (script.GetType() == typeof(CatchPastaController))
        {
            (script as CatchPastaController).PlayGame();
        }
    }
}
