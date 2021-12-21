using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutFade : Fade
{
    [SerializeField] private float delay;

    private void Awake()
    {
        Color fadeColor = fadeImage.color;
        fadeColor.a = 0f;
        fadeImage.color = fadeColor;
    }

    private void Start()
    {
        StartCoroutine("WaitAndFade");
    }

    IEnumerator WaitAndFade()
    {
        yield return new WaitForSeconds(delay);
        StartFadeAnim();
    }
}
