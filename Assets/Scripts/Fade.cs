using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fadeImage;
    public float fadeTime = 1f;
    private float time;
    [SerializeField][Range(0f, 1f)] protected float start;
    [SerializeField][Range(0f, 1f)] protected float end;
    private bool isPlaying;

    virtual public void StartFadeAnim()
    {
        if (isPlaying == true) //�ߺ��������
        {
            return;
        }
        if (start > end) StartCoroutine("fadeoutplay");    //�ڷ�ƾ ����
        else StartCoroutine("fadeinplay"); 
    }

    IEnumerator fadeoutplay()
    {
        isPlaying = true;

        Color fadeColor = fadeImage.color;
        time = 0f;

        while (fadeColor.a > 0f) // fadeout ����
        {
            time += Time.deltaTime / fadeTime;
            fadeColor.a = Mathf.Lerp(start, end, time);
            fadeImage.color = fadeColor;
            yield return null;
        }
    }
    IEnumerator fadeinplay()
    {
        isPlaying = true;

        Color fadecolor = fadeImage.color;
        time = 0f;

        while (fadecolor.a < 1f) // fadein ����
        {
            time += Time.deltaTime / fadeTime;
            fadecolor.a = Mathf.Lerp(start, end, time);
            fadeImage.color = fadecolor;
            yield return null;
        }
    }
}
