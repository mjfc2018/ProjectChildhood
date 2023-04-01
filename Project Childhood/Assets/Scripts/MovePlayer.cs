using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 0.6f;
    public float horizontalLimit = 2.3f; 

    public float bulletSpeed = 1.8f;
    public GameObject bulletPrefab;
    private bool bulletFired = false;

    private float input;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move of the player.
		rb.velocity = new Vector2(Input.GetAxis("Horizontal") * horizontalSpeed, verticalSpeed);

		// Keep the player within bounds.
		if (transform.position.x > horizontalLimit) {
			transform.position = new Vector2 (horizontalLimit, transform.position.y);
		} else if (transform.position.x < -horizontalLimit) {
			transform.position = new Vector2 (-horizontalLimit, transform.position.y);
		}

        // Bullet control
        if(Input.GetAxis("Jump") == 1f) {
            if(bulletFired == false) {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.SetParent(transform.parent);
                bullet.transform.position  = transform.position;

                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
                Destroy(bullet, 3f);
                bulletFired = true;
                Invoke("WaitTime", 0.5f);
            }
            
        }
    }

    void WaitTime()
    {
        bulletFired = false;
    }
    void FixedUpdate()
    {
        
        // input = Input.GetAxisRaw("Horizontal");
        
        // rb.velocity = new Vector2(input * horizontalSpeed, rb.velocity.y);
    }
}
