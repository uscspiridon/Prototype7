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
        // xInput = Input.GetAxisRaw("Horizontal");
        // yInput = Input.GetAxisRaw("Vertical");
        
        // move towards mouse position
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void FixedUpdate() {
        if (xInput != 0 || yInput != 0) {
            Vector2 direction = new Vector2(xInput, yInput);
            direction.Normalize();
            rb.velocity = speed * direction;
        }
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
