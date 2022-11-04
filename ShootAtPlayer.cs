using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    public GameObject projectile;

    private float timerShoot;
    private float randomTime;

    public float randomMin;
    public float randomMax;

    void Start()
    {
        randomTime = Random.Range(randomMin, randomMax);
    }

    void Update()
    {
        timerShoot += Time.deltaTime;
        if (timerShoot > randomTime) {
            if (GameObject.Find("Player(Clone)")) {
                GameObject player = GameObject.Find("Player(Clone)");
                float differenceX = Mathf.Abs(player.transform.position.x - transform.position.x);
                float differenceY = Mathf.Abs(player.transform.position.y - transform.position.y);
                if (differenceX < 10 && differenceY < 10) {
                    Instantiate(projectile, transform.position, projectile.transform.rotation);
                    randomTime = Random.Range(randomMin, randomMax);
                    timerShoot = 0.0f;
                }
            }
        }
    }
}
