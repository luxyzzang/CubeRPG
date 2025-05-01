using System.Collections;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private Transform cube;
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private float scaleSpeed = 0.1f;

    private void Start()
    {
        StartCoroutine(CubeMove(3, 5));
        StartCoroutine(CubeRotate(3, 180));
        StartCoroutine(CubeScale());
    }

    private IEnumerator CubeMove(float duration, float goalPosX)
    {
        float startTime = 0;
        while (true)
        {
            startTime += Time.deltaTime;
            float t = startTime / duration;
            cube.position = Vector3.Lerp(Vector3.zero, new Vector3(goalPosX, 0, 0), t);
            yield return null;

            if (t >= 1) break;
        }
    }

    private IEnumerator CubeRotate(float duration, float goalRotY)
    {
        float startTime = 0;
        while (true)
        {
            startTime += Time.deltaTime;
            float t = startTime / duration;
            cube.eulerAngles = Vector3.Lerp(Vector3.zero, new Vector3(0, goalRotY, 0), t);
            yield return null;

            if (t >= 1) break;
        }
    }

    private IEnumerator CubeScale()
    {
        float scale = 1;

        while (scale < 3)
        {
            cube.localScale = new Vector3(scale, scale, scale);
            scale += 0.1f * scaleSpeed;
            yield return null;
        }
    }
}
