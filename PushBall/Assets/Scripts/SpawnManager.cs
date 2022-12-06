using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject powerUpPrefab;
    private float spawnRange = 9.0f;
    [SerializeField] int enemyCount;
    [SerializeField] int waveNumber = 1;
    void Start()
    {

        SpawnEnemy(waveNumber);
       
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemy(waveNumber);
            SpawnPowerUp();
        }
    }
    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosY);
        return randomPos;
    }
    void SpawnEnemy(int enemySpawnCount)
    {
        for(int i = 0; i < enemySpawnCount; i++)
        {
           Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
    void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);
    }
}
