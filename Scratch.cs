using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scratch : MonoBehaviour
{
    private Vector3 playerPos;
    public float damage;
    private float timerCooldown;
    private bool inCooldown;

    void Start()
    {
        playerPos = new Vector3(50, 50, 0); // arbitrary to allow Update() to function and prevent faulty hits
    }

    void Update()
    {
        if (inCooldown) {
            timerCooldown += Time.deltaTime;
            if (timerCooldown >= 1.5) {
                inCooldown = false;
                timerCooldown = 0.0f;
            }
        }

        if (GameObject.Find("Player(Clone)")) {
            playerPos = GameObject.Find("Player(Clone)").transform.position;

            if ((Mathf.Abs(transform.position.x - playerPos.x) < 0.5f) && (Mathf.Abs(transform.position.y - playerPos.y) < 0.5f)) {
                if (!inCooldown) {
                    GameObject.Find("Player(Clone)").GetComponent<HealthManager>().PlayerDamage(damage);
                    inCooldown = true;
                }
            }
        }
    }
}
