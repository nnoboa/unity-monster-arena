using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>(); // constrained to index 0-3
    private float value; // reserved for health or armor

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateValue(float change)
    {
        value += change;
        int index = (int)Mathf.Floor(value/3);

        if (index > 3) {
            index = 3;
        }
        if (index < 0) {
            index = 0;
        }

        this.GetComponent<SpriteRenderer>().sprite = sprites[index];
    }
}
