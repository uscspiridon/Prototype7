using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour {

    // constants
    public GameObject bulletPrefab;
    public float reloadTime;
    public int bulletAmount = 5;
    public float startAngle = 0f, endAngle = 360f;
    public bool targetPlayer;
    
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
            float angleStep = (endAngle - startAngle) / bulletAmount;
            float angle = startAngle;

            if (targetPlayer) {
                Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
                bullet.DirectAtTarget(PlayerMovement.Instance.transform.position);
            }
            else {
                for (int i = 0; i < bulletAmount; i++)
                {
                    float bullDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                    float bullDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                    Vector3 bullMoveVector = new Vector3(bullDirX, bullDirY, 0f);
                    Vector2 bullDir = (bullMoveVector - transform.position).normalized;

                    Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
                    bullet.SetDirection(bullDir);

                    angle += angleStep;
                } 
            }

            // reset reload timer
            reloadTimer = reloadTime;
        }
    }
}
