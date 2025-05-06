using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public static class UIExtension
{
    public static IEnumerator ChangeColor(this Image img, Color changeColor, float duration)
    {
        float startTime = 0;
        Color startColor = img.color;

        while (startTime < duration)
        {
            startTime += Time.deltaTime;
            float t = startTime / duration;
            img.color = Color.Lerp(startColor, changeColor, t);
            yield return null;
        }
    }

    public static IEnumerator Fade(this Image img, float fade, float duration)
    {
        float startTime = 0;
        Color startColor = img.color;
        Color fadeColor = img.color;
        fadeColor.a = fade;

        while (startTime < duration)
        {
            startTime += Time.deltaTime;
            float t = startTime / duration;
            img.color = Color.Lerp(startColor, fadeColor, t);
            yield return null;
        }
    }
}