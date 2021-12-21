using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSceneToCutScene : LoadScene
{
    private StageMenuManager stageMenuManager;

    private void Awake()
    {
        stageMenuManager = GameObject.Find("StageMenuManager").GetComponent<StageMenuManager>();
    }

    public override void StageSceneLoder(string sceneName)
    {
        if(PlayerPrefs.GetInt("IsOpenCutScene") == 1 || stageMenuManager.openCutScene)
            base.StageSceneLoder(sceneName);
    }
}
