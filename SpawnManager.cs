using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<GameObject> items;
    private int counterWave;
    private bool respawnWave;
    private float timerRespawn;

    void Start()
    {
        counterWave = 0;
    }

    void Update()
    {
        int counterEnemies =  GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (counterEnemies == 0) {
            respawnWave = true;
        }

        if (respawnWave) {
            timerRespawn += Time.deltaTime;
            if (timerRespawn > 3.0f) {
                counterWave += 5;
                SpawnWave();
                respawnWave = false;
                timerRespawn = 0.0f;
            }
        }
    }

    public void SpawnWave()
    {
        // spawn enemies
        for (int i = 0; i < counterWave + 20; i++) {
            int index = Random.Range(0, enemies.Count);
            Instantiate(enemies[index], GenerateSpawnPosition(), enemies[index].transform.rotation);
        }

        // spawn items
        for (int i = 0; i < 3; i++) {
            int index = Random.Range(0, items.Count);
            Instantiate(items[index], GenerateSpawnPosition(), items[index].transform.rotation);
        }
    }

    // will need error handling to ensure enemies don't spawn in walls, traps, etc.
    private Vector2 GenerateSpawnPosition()
    {
        PlayerController player = GameObject.Find("Player(Clone)").GetComponent<PlayerController>(); // will only work while player is alive
        float spawnRange = 15.0f;
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnY = Random.Range(-spawnRange, spawnRange);

        while (Mathf.Abs(spawnX - player.transform.position.x) < 1) {
            spawnX = Random.Range(-spawnRange, spawnRange);
        }
        while (Mathf.Abs(spawnY - player.transform.position.y) < 1) {
            spawnY = Random.Range(-spawnRange, spawnRange);
        }

        return new Vector2(spawnX, spawnY);
    }
}
