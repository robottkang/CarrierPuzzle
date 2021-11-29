using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePresentStageToNextStage : LoadScene
{
    private int stageNumber;

    private void Awake()
    {
        stageNumber = PlayerPrefs.GetInt("StageNumber");
    }

    public override void StageSceneLoder(string sceneName)
    {
        PlayerPrefs.SetInt("StageNumber", ++stageNumber);
        base.StageSceneLoder(sceneName);
    }
}
