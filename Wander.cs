using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    private float timerMovement;
    private float randomTime;

    public float randomMin;
    public float randomMax;

    void Start()
    {
        randomTime = Random.Range(randomMin, randomMax);
    }

    void Update()
    {
        timerMovement += Time.deltaTime;
        if (timerMovement >= randomTime) {
            GenerateNewPosition();
            randomTime = Random.Range(randomMin, randomMax);
            timerMovement = 0.0f;
        }   
    }

    private void GenerateNewPosition()
    {
        float xDirection = 0;
        float yDirection = 0;

        if (Random.Range(1,11) <= 5) {
            xDirection = Random.Range(1.0f, 4.0f) - 2;
        }
        else {
            yDirection = Random.Range(1.0f, 4.0f) - 2;
        }

        Vector2 newPos = new Vector2(transform.position.x + xDirection, transform.position.y + yDirection);

        if (!CheckForWalls(newPos)) {
            transform.position = newPos;
        }
    }

    // how to handle obstacles - own script, or per movement script?
    private bool CheckForWalls(Vector2 newPos)
    {
        if (newPos.x > 10 || newPos.x < -10 || newPos.y > 10 || newPos.y < -10) {
            return true;
        }

        return false;
    }
}
