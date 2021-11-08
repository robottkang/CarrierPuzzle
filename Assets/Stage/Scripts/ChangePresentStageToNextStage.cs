using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePresentStageToNextStage : LoadScene
{
    private StageMenuManager stageMenuManager;
    private void Start()
    {
        stageMenuManager = GameObject.Find("StageMenuManager").GetComponent<StageMenuManager>();
    }
    public override void StageSceneLoder(string sceneName)
    {
        stageMenuManager.EnteredStageNumber += 1;
        base.StageSceneLoder(sceneName);
    }
}
