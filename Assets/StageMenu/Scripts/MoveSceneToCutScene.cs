using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSceneToCutScene : LoadScene
{
    public override void StageSceneLoder(string sceneName)
    {
        if(PlayerPrefs.GetInt("IsOpenCutScene") == 1)
            base.StageSceneLoder(sceneName);
    }
}
