using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerChangeColor : MonoBehaviour {

    public Color baseColor, triggerColor, collisionColor;
    bool collision = false, trigger = false;
    // Use this for initialization
    void Start() {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        this.GetComponent<SpriteRenderer>().color = triggerColor;
        trigger = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        trigger = false;
        if (!collision)
            this.GetComponent<SpriteRenderer>().color = baseColor;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        collision = true;
        this.GetComponent<SpriteRenderer>().color = collisionColor;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        collision = false;
        if (!trigger)
            this.GetComponent<SpriteRenderer>().color = baseColor;


    }

    // Update is called once per frame
    void Update () {
		
	}
}
