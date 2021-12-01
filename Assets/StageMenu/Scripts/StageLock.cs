using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageLock : MonoBehaviour
{
    [SerializeField] private Color activeColor;
    [SerializeField] private Color deactiveColor;

    private void Update()
    {
        CheckIsStageClear();
    }

    private void CheckIsStageClear()
    {
        if ((PlayerPrefs.GetInt("ClearData") + 1) >= gameObject.GetComponentInChildren<StageNumber>().stageNumber)
        {
            gameObject.GetComponent<Image>().color = activeColor;
        }
        else
        {
            gameObject.GetComponent<Image>().color = deactiveColor;
        }
    }
}