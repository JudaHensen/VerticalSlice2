using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [Header("How many levels have passed + 1")]
    [SerializeField]
    private int currentLevel; //, amountOfWaves, enemysPerWave;

    [Header("Boss prefab")]
    [SerializeField]
    private GameObject bossPrefab;

    [Header("Boss parent gameObject")]
    [SerializeField]
    private GameObject bossParent;

    [Header("Boss spawn location")]
    [SerializeField]
    private Vector3 bossSpawnLocation;

    [Header("Time until the boss spawns")]
    [SerializeField]
    private float bossSpawnTime;

    private bool bossSpawned = false;
    private bool bossSlain = false;
    private float spawnTimer;

    // spawn boss after a small delay
    void Update()
    {
        if(!bossSpawned)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= bossSpawnTime) SpawnBoss();
        }
        
    }


    // spawn the boss
    private void SpawnBoss()
    {
        bossSpawned = true;
        GameObject boss = Instantiate(bossPrefab, bossSpawnLocation, Quaternion.identity);
        boss.transform.SetParent(bossParent.transform);
    }

    public bool BossSlain
    {
        get {
            return bossSlain;
        }
        set {
            bossSlain = value;
        }
    }

}
