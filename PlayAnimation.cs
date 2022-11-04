using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();

    private float timerAnimation;
    private int spriteTracker;

    void Start()
    {
        spriteTracker = 0;
    }

    void Update()
    {
        timerAnimation += Time.deltaTime;
        if (timerAnimation >= 0.1f) {
            if (spriteTracker >= sprites.Count) {
                Destroy(gameObject);
            }
            else {
                this.GetComponent<SpriteRenderer>().sprite = sprites[spriteTracker];
            }
            timerAnimation = 0.0f;
            spriteTracker++;
        }
    }
}