using System.Collections;
using UnityEngine;

public static class TransformExtension
{
    public static IEnumerator Move(this Transform target, Vector3 pos, float duration)
    {
        float startTime = 0;
        Vector3 startPos = target.position;

        while (startTime < duration)
        {
            startTime += Time.deltaTime;
            float t = startTime / duration;
            target.position = Vector3.Lerp(startPos, pos, t);
            yield return null;
        }
    }
}