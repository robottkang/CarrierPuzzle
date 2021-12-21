using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePresentStageToNextStage : LoadScene
{
    private int stageNumber;
    [SerializeField] private string cutScene;

    private void Awake()
    {
        stageNumber = PlayerPrefs.GetInt("StageNumber");
    }

    public override void StageSceneLoder(string sceneName)
    {
        if (stageNumber < 10)
        {
            PlayerPrefs.SetInt("StageNumber", ++stageNumber);
            Debug.Log("Stage Number : " + stageNumber);
            base.StageSceneLoder(sceneName);
        }
        else// 10 stage �Ϸ��ϸ� CutScene����
        {
            Debug.Log("All Stage Clear");
            PlayerPrefs.SetInt("IsOpenCutScene", 1);
            base.StageSceneLoder(cutScene);
        }
    }
}
