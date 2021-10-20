using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EncircledArea : MonoBehaviour {
    [HideInInspector] public CircleCollider2D collider;

    public static EncircledArea Instance;

    private float activeTimer;

    private SpriteRenderer sprite;

    private void Awake() {
        Instance = this;
        collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (activeTimer > 0) {
            activeTimer -= Time.deltaTime;
            Debug.Log("destroying enemies for " + activeTimer);
            sprite.enabled = true;
        } 
        else sprite.enabled = false;

    }

    public void DestroyEnemiesInside() {
        activeTimer = 0.5f;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (activeTimer > 0) {
            Debug.Log("colliding with " + other.name);
            if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Bullet")) Destroy(other.gameObject);    
        }
    }
}
