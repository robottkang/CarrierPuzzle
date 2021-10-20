using UnityEngine;

public class ChangeScenesToStage : LoadScene
{
    [SerializeField] private GameObject stageMenuManager;
    [SerializeField] private StageNumber stageNumber;

    public override void StageSceneLoder(string sceneName)
    {
        stageMenuManager.GetComponent<StageMenuManager>().EnteredStageNumber = stageNumber.stageNumber;
        base.StageSceneLoder(sceneName);
        DontDestroyOnLoad(stageMenuManager);
    }
}