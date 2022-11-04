using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public bool isHealth;
    public bool isArmor;
    public int value;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameObject.Find("Player(Clone)")) {
            Vector2 playerPos = GameObject.Find("Player(Clone)").transform.position;

            if ((Mathf.Abs(transform.position.x - playerPos.x) < 0.5f) && (Mathf.Abs(transform.position.y - playerPos.y) < 0.5f)) {
                if (isHealth) {
                    GameObject.Find("Player(Clone)").GetComponent<HealthManager>().Health = value;
                }
                if (isArmor) {
                    GameObject.Find("Player(Clone)").GetComponent<HealthManager>().Armor = value;
                }

                Destroy(gameObject);
            }
        }
    }
    

}
