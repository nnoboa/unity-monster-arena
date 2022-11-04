using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnvironment : MonoBehaviour
{
    public GameObject wall;

    void Start()
    {
        int spawnX = -16;
        for (int i = 0; i <= 32; i++) {
            Instantiate(wall, new Vector2(spawnX, 16), wall.transform.rotation);
            Instantiate(wall, new Vector2(spawnX, -16), wall.transform.rotation);
            spawnX++;
        }

        int spawnY = -16;
        for (int i = 0; i <= 32; i++) {
            Instantiate(wall, new Vector2(16, spawnY), wall.transform.rotation);
            Instantiate(wall, new Vector2(-16, spawnY), wall.transform.rotation);
            spawnY++;
        }
    }

    void Update()
    {
        
    }
}
