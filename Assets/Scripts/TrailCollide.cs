using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCollide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision.name);
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Player")) {
            Debug.Log("trail collide with player at " + transform.position);
            EncircledArea.Instance.transform.position = TrailController.Instance.center;
            EncircledArea.Instance.transform.localScale = new Vector3(TrailController.Instance.diameter, TrailController.Instance.diameter, 1);
            EncircledArea.Instance.DestroyEnemiesInside();
            TrailController.Instance.trail.Clear();
        }
    }
}
