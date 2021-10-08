using UnityEngine;
using TMPro;

public class StageNumber : MonoBehaviour
{
    [SerializeField] private int stageNumber;
    private TextMeshProUGUI stageNumberText;
    [SerializeField] private StageMenuManager stageMenuNumber;
    private void Awake()
    {
        stageNumberText = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        stageNumberText.text = "" + ((stageMenuNumber.StageMenuNumber - 1) * 10 + stageNumber);
    }
}
