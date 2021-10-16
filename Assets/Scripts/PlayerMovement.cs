using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {
    // necessary junk
    private Rigidbody2D rb;
    public static PlayerMovement Instance;
    
    // public constants
    public float speed;
    // public float diagonalInputRampTime;
    
    // state variables
    private float xInput;
    private float yInput;

    private void Awake() {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        // // x input
        // if (Input.GetAxisRaw("Horizontal") == 1) {
        //     if (yInput == 0) xInput = 1;
        //     if (xInput < 0) xInput = 0;
        //     xInput += 1/diagonalInputRampTime * Time.deltaTime;
        //     if (xInput > 1) xInput = 1;
        // }
        // else if (Input.GetAxisRaw("Horizontal") == -1) {
        //     if (yInput == 0) xInput = -1;
        //     if (xInput > 0) xInput = 0;
        //     xInput -= 1/diagonalInputRampTime * Time.deltaTime;
        //     if (xInput < -1) xInput = -1;
        // }
        // else xInput = 0;
        // // y input
        // if (Input.GetAxisRaw("Vertical") == 1) {
        //     if (xInput == 0) yInput = 1;
        //     if (yInput < 0) yInput = 0;
        //     yInput += 1/diagonalInputRampTime * Time.deltaTime;
        //     if (yInput > 1) yInput = 1;
        // }
        // else if (Input.GetAxisRaw("Vertical") == -1) {
        //     if (xInput == 0) yInput = -1;
        //     if (yInput > 0) yInput = 0;
        //     yInput -= 1/diagonalInputRampTime * Time.deltaTime;
        //     if (yInput < -1) yInput = -1;
        // }
        // else yInput = 0;
        // Debug.Log("x: " + xInput + " y: " + yInput);

        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        Vector2 direction = new Vector2(xInput, yInput);
        direction.Normalize();
        rb.velocity = speed * direction;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (other.gameObject.CompareTag("Bullet")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
