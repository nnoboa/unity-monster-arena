using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimation : MonoBehaviour
{
    public Sprite idle1;
    public Sprite idle2;

    public float animationTime;
    private float timerAnimation;
    private int spriteTracker;

    void Start()
    {
        spriteTracker = 1;
    }

    void Update()
    {
        timerAnimation += Time.deltaTime;
        if (timerAnimation >= animationTime) {
            if (spriteTracker == 1) {
                spriteTracker = 2;
                this.GetComponent<SpriteRenderer>().sprite = idle2;
            }
            else if (spriteTracker == 2) {
                spriteTracker = 1;
                this.GetComponent<SpriteRenderer>().sprite = idle1;
            }
            timerAnimation = 0.0f;
        }
    }
}