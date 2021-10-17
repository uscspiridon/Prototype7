using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCollide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
