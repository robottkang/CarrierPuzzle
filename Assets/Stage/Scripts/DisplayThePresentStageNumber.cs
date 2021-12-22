using UnityEngine;
using TMPro;

public class DisplayThePresentStageNumber : MonoBehaviour
{
    private TextMeshProUGUI stageNumberText;

    private void Awake()
    {
        stageNumberText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        stageNumberText.text = "" + PlayerPrefs.GetInt("StageNumber");
    }
}
