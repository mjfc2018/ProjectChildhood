using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MoveEnemyAirPlane : MonoBehaviour
{
    public delegate void KillHandler();
    public event KillHandler OnKill;

    [SerializeField]
    Text scorePanel;

    private int score;

    public GameObject bulletPrefab;
    public float speed;
    public float bulletSpeed;
    public float shootingInterval = 3f;

    private float shootingTimer;

    [SerializeField]
    AudioSource audioFX;

    [SerializeField]
    AudioClip shootAudioClip;

    [SerializeField]
    AudioClip fireHitClip;


    // Use this for initialization
    void OnEnable()
    {
        shootingTimer = Random.Range(0f, shootingInterval);

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        shootingTimer -= Time.deltaTime;
        if (shootingTimer <= 0f)
        {
            shootingTimer = shootingInterval;
            audioFX.PlayOneShot(shootAudioClip);
            GameObject bulletInstance = Instantiate(bulletPrefab);
            bulletInstance.transform.SetParent(transform.parent);
            bulletInstance.transform.position = transform.position;
            bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
            Destroy(bulletInstance, 3f);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "PlayerBullet")
        {
            audioFX.PlayOneShot(fireHitClip);
            gameObject.SetActive(false);
            Destroy(otherCollider.gameObject);

            if (OnKill != null)
            {
                OnKill();
            }
        }
    }
}
