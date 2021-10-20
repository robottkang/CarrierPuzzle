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
        stageNumberText = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        stageNumberText.text = "" + stageNumber;
    }
}
