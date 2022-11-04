using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject blood;
    private UpdateUI uiHealth;
    private UpdateUI uiArmor;
    public float health;
    public float armor;
    public bool isPlayer;

    void Start()
    {
        if (isPlayer) {
            uiHealth = GameObject.Find("UI_Health").GetComponent<UpdateUI>();
            uiArmor = GameObject.Find("UI_Armor").GetComponent<UpdateUI>();
            uiHealth.UpdateValue(health);
            uiArmor.UpdateValue(armor);
        }
    }

    void Update()
    {
        
    }

    public float Health
    {
        get {
            return health;
            }
        set {
            health += value;

            if (value < 0) {
                VisualizeDamage(value);
            }

            CheckHealth();
        }
    }

    public float Armor
    {
        get {
            return armor;
        }
        set {
            armor += value;

            if (isPlayer) {
                uiArmor.UpdateValue(value);
            }
        }
    }

    public void PlayerDamage(float damage)
    {
        float a = armor;
        armor -= damage;
        uiArmor.UpdateValue(-damage);
        if (armor < 0) {
            armor = 0;
        }

        if (a < damage) {
            damage -= a;
            health -= damage;
            uiHealth.UpdateValue(-damage);
        }

        CheckHealth();
    }

    private void VisualizeDamage(float damage)
    {
        int counter = 0;
        damage = Mathf.Abs(damage); // passes to function as -1
        while (counter < damage) {
            float offsetX = Random.Range(-0.5f, 0.5f);
            float offsetY = Random.Range(-0.5f, 0.5f);
            Vector2 spawnPos = new Vector2(transform.position.x + offsetX, transform.position.y + offsetY);
            Instantiate(blood, spawnPos, blood.transform.rotation);
            counter++;
        }
    }

    private void CheckHealth()
    {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
