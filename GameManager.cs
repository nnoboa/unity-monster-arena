using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private SpawnManager spawnManager;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        Instantiate(player, new Vector2(0,0), player.transform.rotation);
    }

    void Update()
    {
        
    }
}
