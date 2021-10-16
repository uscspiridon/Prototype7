using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour {

    // constants
    public GameObject bulletPrefab;
    public float reloadTime;
    
    // state
    private float reloadTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        // fire bullets
        reloadTimer -= Time.deltaTime;
        if (reloadTimer <= 0) {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
            bullet.targetPos = PlayerMovement.Instance.transform.position;
            // reset reload timer
            reloadTimer = reloadTime;
        }
    }
}
