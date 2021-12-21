using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageFade : Fade
{
    [SerializeField] private GameManager gameManager;

    private void Update()
    {
        if (gameManager.IsClear)
        {
            StartFadeAnim();
        }
    }
}
