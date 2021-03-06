using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {
    private Rigidbody2D rb;

    // [HideInInspector] public Vector3 targetPos;
    public float speed;
    public float despawnDistance;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    public void DirectAtTarget(Vector3 targetPos) {
        SetDirection(targetPos - transform.position);
    }

    public void SetDirection(Vector3 dir)
    {
        Vector3 direction = dir;
        direction.Normalize();
        rb.velocity = speed * direction;
    }

    // Update is called once per frame
    void Update() {
        float distance = Vector3.Distance(PlayerMovement.Instance.transform.position, transform.position);
        if (distance > despawnDistance) {
            Destroy(gameObject);
        }
    }
}
