using UnityEngine;

public class StageMenuManager : MonoBehaviour
{
    [SerializeField] private int stageMenuNumber = 1;
    public int StageMenuNumber { get => stageMenuNumber; set => stageMenuNumber = value; }
    [SerializeField] private int theNumberOfStageMenu = 5;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject previousButton;
    [SerializeField] private bool openAllStage;
    [SerializeField] private bool resetStage;

    private void Awake()
    {
        Debug.Log(PlayerPrefs.GetInt("ClearData"));
        //previousButton.SetActive(false);
    }

    private void Update()
    {
        if (openAllStage == true) PlayerPrefs.SetInt("ClearData", 10);
        if (resetStage) PlayerPrefs.SetInt("ClearData", 0);
    }

    public void ChangeToNextStage()
    {
        stageMenuNumber += 1;
        if (stageMenuNumber == theNumberOfStageMenu) nextButton.SetActive(false);
        else nextButton.SetActive(true);
        previousButton.SetActive(true);
    }

    public void ChangeToPreviousStage()
    {
        stageMenuNumber -= 1;
        if (stageMenuNumber == 1) previousButton.SetActive(false);
        else previousButton.SetActive(true);
        nextButton.SetActive(true);
    }
}