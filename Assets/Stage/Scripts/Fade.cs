using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Image image;
    [SerializeField] float max;
    private bool isEndChangingColor;

    private void Start()
    {
        isEndChangingColor = false;
    }

    private void Update()
    {
        if (gameManager.IsClear || !isEndChangingColor)
        {
            StartCoroutine("Gradient");
        }
    }

    IEnumerator Gradient()
    {
        for (float i = 0; i <= max; i += max/80)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, i / 24);
            yield return isEndChangingColor = true;
        }
    }
}
