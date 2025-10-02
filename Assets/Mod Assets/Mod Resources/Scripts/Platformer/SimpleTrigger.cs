using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class SimpleTrigger : MonoBehaviour
{

    public Rigidbody2D triggerBody; 
    public UnityEvent onTriggerEnter;
    public GameObject[] tokens;

    private void Start()
    {
        //find object by tag
        tokens = GameObject.FindGameObjectsWithTag("Bonus Token");

        foreach (GameObject token in tokens)
        {
            SpriteRenderer spriteRenderer = token.GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        //do not trigger if there's no trigger target object
        if (triggerBody == null) return;


        //only trigger if the triggerBody matches
        var hitRb = other.attachedRigidbody;
        if (hitRb == triggerBody){
            onTriggerEnter.Invoke();

           
            foreach (GameObject token in tokens)
            {
                SpriteRenderer spriteRenderer = token.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = true;

                CircleCollider2D circleCollider2D = token.GetComponent<CircleCollider2D>();
                circleCollider2D.enabled = true;
            }
        }
    }

}
