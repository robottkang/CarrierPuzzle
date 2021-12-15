using UnityEngine;

public class MoveScenesToStage : LoadScene
{
    [SerializeField] StageNumber stageNumber;
    private void Awake()
    {
        if (stageNumber == null) stageNumber = gameObject.GetComponentInChildren<StageNumber>();
    }

    public override void StageSceneLoder(string sceneName)
    {
        if ((PlayerPrefs.GetInt("ClearData") + 1) >= stageNumber.stageNumber)
        {
            PlayerPrefs.SetInt("StageNumber", stageNumber.stageNumber);
            base.StageSceneLoder(sceneName);
        }
    }
}