using UnityEngine;
using TMPro;

public class StageNumber : MonoBehaviour
{
    [SerializeField] private int stageOrder;
    public int stageNumber => stageOrder + 10 * (stageMenuNumber.StageMenuNumber - 1);
    private TextMeshProUGUI stageNumberText;
    [SerializeField] private StageMenuManager stageMenuNumber;
    private void Awake()
    {
        if (stageMenuNumber == null) stageMenuNumber = GameObject.Find("StageMenuNumber").GetComponent<StageMenuManager>();
        stageNumberText = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        stageNumberText.text = "" + stageNumber;
    }
}
