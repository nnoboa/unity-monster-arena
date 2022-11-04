using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private float speed;
    private float timerMove;
    private float randomTime;

    public float randomMin;
    public float randomMax;

    void Start()
    {
        randomTime = Random.Range(randomMin, randomMax);
        speed = 1.0f;
    }

    void Update()
    {
        timerMove += Time.deltaTime;

        if (timerMove > randomTime) {
           if (GameObject.Find("Player(Clone)")) {
                GameObject player = GameObject.Find("Player(Clone)");
                Vector2 playerLocation = new Vector2(player.transform.position.x, player.transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, playerLocation, speed);
                randomTime = Random.Range(randomMin, randomMax);
                timerMove = 0.0f;
           }
        }
    }
}