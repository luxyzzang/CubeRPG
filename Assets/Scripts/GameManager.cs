using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player")]
    [SerializeField] private GameObject playerPref;
    private GameObject player;

    [Header("Monster")]
    [SerializeField] private GameObject enemyPref;
    private List<GameObject> enemies = new List<GameObject>();

    [SerializeField] private int monsterSpawnCnt = 10;
    [SerializeField] private float spawnAreaWidth = 40f;
    [SerializeField] private float spawnAreaHeight = 40f;
    [SerializeField] private float spawnAreaMargin = 1f;
    private float spawnAreaHalfWidth;
    private float spawnAreaHalfHeight;

    public float SpawnAreaHalfWidth => spawnAreaWidth;
    public float SpawnAreaHalfHeight => spawnAreaHeight;

    private void Awake()
    {
        instance = this;

        spawnAreaHalfWidth = spawnAreaWidth / 2 - spawnAreaMargin;
        spawnAreaHalfHeight = spawnAreaHeight / 2 - spawnAreaMargin;
    }

    private void Start()
    {
        SpawnPlayer();
        SpawnMonster();
    }

    private void SpawnPlayer() => player = Instantiate(playerPref);

    private void SpawnMonster()
    {
        for (int i = 0; i < monsterSpawnCnt; i++)
        {
            float spawnPosX = Random.Range(-spawnAreaHalfWidth, spawnAreaHalfWidth);
            float spawnPosZ = Random.Range(-spawnAreaHalfHeight, spawnAreaHalfHeight);
            float spawnRotY = Random.Range(0, 360f);

            Vector3 spawnPos = new Vector3(spawnPosX, enemyPref.transform.position.y, spawnPosZ);
            Quaternion spawnRot = Quaternion.Euler(0, spawnRotY, 0);
            GameObject enemy = Instantiate(enemyPref, spawnPos, spawnRot);
            enemies.Add(enemy);
        }
    }
}