using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {
    // component stuff
    private Rigidbody2D rb;
    
    // public constants
    public float speed;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        rb.velocity = speed * Time.deltaTime * new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
