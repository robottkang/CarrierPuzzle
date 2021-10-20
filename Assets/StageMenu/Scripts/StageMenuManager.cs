using UnityEngine;

public class StageMenuManager : MonoBehaviour
{
    [SerializeField] private int stageMenuNumber = 1;
    public int StageMenuNumber { get => stageMenuNumber; set => stageMenuNumber = value; }
    private int enteredStageNumber;
    public int EnteredStageNumber { get => enteredStageNumber; set => enteredStageNumber = value; }
    [SerializeField] private int theNumberOfStageMenu = 5;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject previousButton;

    private void Awake()
    {
        previousButton.SetActive(false);
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