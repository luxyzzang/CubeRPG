using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveDistanceMin = 2f;
    [SerializeField] private float moveDistanceMax = 4f;
    [SerializeField] private float moveDelay = 1f;
    [SerializeField] private float moveSpeed = 3f;

    private float spawnAreaHalfWidth;
    private float spawnAreaHalfHeight;
    private Vector3 pos;

    private void Start()
    { 
        spawnAreaHalfWidth = GameManager.instance.SpawnAreaHalfWidth;
        spawnAreaHalfHeight = GameManager.instance.SpawnAreaHalfHeight;
        StartCoroutine(MoveEnemy());
    }

    private void Update()
    {
        RotateEnemy();
    }

    private IEnumerator MoveEnemy()
    {
        while (true)
        {
            float randomMoveDistance = Random.Range(moveDistanceMin, moveDistanceMax);
            Vector2 randomCircle = Random.insideUnitCircle * randomMoveDistance;
            
            pos = transform.position;
            pos.x += randomCircle.x;
            pos.z += randomCircle.y;

            pos.x = Mathf.Clamp(pos.x, -spawnAreaHalfWidth, spawnAreaHalfWidth);
            pos.z = Mathf.Clamp(pos.z, -spawnAreaHalfHeight, spawnAreaHalfHeight);

            float duration = randomMoveDistance / moveSpeed;

            StartCoroutine(transform.Move(pos, duration));
            yield return new WaitForSeconds(randomMoveDistance + moveDelay);
        }
    }

    private void RotateEnemy()
    {
        Vector3 dir = (pos - transform.position).normalized;
        if (dir != Vector3.zero) 
        {
            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 75 * Time.deltaTime);
        }
    }
}
