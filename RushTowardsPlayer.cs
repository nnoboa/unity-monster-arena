using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushTowardsPlayer : MonoBehaviour
{
    private float timerWait;
    public float waitTime;
    private float timerCharge;
    public float chargeTime;
    private float speed;
    private float offset;

    void Start()
    {
        offset = Random.Range(-2.0f, 2.0f); // make movement occur at different intervals from others
        waitTime += offset;
        speed = 0.25f;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        timerWait += Time.deltaTime;

        if(timerWait > waitTime) {
            if (GameObject.Find("Player(Clone)")) {
                GameObject player = GameObject.Find("Player(Clone)");
                
                timerCharge += Time.deltaTime;
                if (timerCharge < chargeTime) {
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
                }
                else {
                    timerCharge = 0.0f;
                    timerWait = 0.0f;
                }
            }
        }
    }
}
