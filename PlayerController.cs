using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    private float timerProjectile;
    private float speed;

    void Start()
    {
        speed = 0.1f;
    }

    void Update()
    {
        timerProjectile += Time.deltaTime;

        if (Input.GetButton("Jump")) {
            if (timerProjectile > 0.25f) {
                Instantiate(projectile, transform.position, projectile.transform.rotation);
                timerProjectile = 0.0f;
            }
        }
    }

    void FixedUpdate()
    {
        float new_x = Input.GetAxisRaw("Horizontal") * speed;
        float new_y = Input.GetAxisRaw("Vertical") * speed;
        transform.position = new Vector2(transform.position.x + new_x, transform.position.y + new_y);
        CheckOutOfBounds();
    }

    private void CheckOutOfBounds()
    {
        float movementRange = 15.0f;

        if (transform.position.x > movementRange) {
            transform.position = new Vector2(movementRange, transform.position.y);
        }
        if (transform.position.x < -movementRange) {
            transform.position = new Vector2(-movementRange, transform.position.y);
        }
        if (transform.position.y > movementRange) {
            transform.position = new Vector2(transform.position.x, movementRange);
        }
        if (transform.position.y < -movementRange) {
            transform.position = new Vector2(transform.position.x, -movementRange);
        }
    }
}
