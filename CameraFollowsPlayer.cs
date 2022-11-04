using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    private GameObject player;
    private GameObject health;
    private GameObject armor;
    private GameObject reset;

    void Start()
    {
        health = GameObject.Find("UI_Health");
        armor = GameObject.Find("UI_Armor");
        reset = GameObject.Find("UI_Button_Reset");
    }

    void Update()
    {
        if (GameObject.Find("Player(Clone)")) {
            player = GameObject.Find("Player(Clone)");
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            health.transform.position = new Vector2(player.transform.position.x - 7.4f, player.transform.position.y - 4.5f);
            armor.transform.position = new Vector2(player.transform.position.x - 4.4f, player.transform.position.y - 4.5f);
            reset.transform.position = new Vector2(player.transform.position.x + 7.4f, player.transform.position.y - 4.5f);
        }
    }
}
