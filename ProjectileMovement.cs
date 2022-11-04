using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Camera view;
    private Rigidbody2D body;

    private Vector2 difference;
    public float speed;

    public bool isEnemy;

    void Start()
    {
        if (isEnemy) {
            if (GameObject.Find("Player(Clone)")) {
                GameObject player = GameObject.Find("Player(Clone)");
                difference = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            }
            // error handler, move towards center
            else {
                difference = new Vector2(0 - transform.position.x, 0 - transform.position.y);
            }
        }
        else {
            view = FindObjectOfType<Camera>();
            Vector3 mousePosition = view.ScreenToWorldPoint(Input.mousePosition);
            difference = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        }

        difference = difference.normalized;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + difference.x * speed, transform.position.y + difference.y * speed);

        if (Mathf.Abs(transform.position.x) > 16 || Mathf.Abs(transform.position.y) > 16) {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isEnemy) {
            if (other.gameObject.CompareTag("Player")) {
                other.GetComponent<HealthManager>().PlayerDamage(1);
                Destroy(gameObject);
            }
        }
        else {
            if (other.gameObject.CompareTag("Enemy")) {
                other.GetComponent<HealthManager>().Health = -1;
                Destroy(gameObject);
            }
        }
    }
}
