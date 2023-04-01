using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public GameObject panelGameOver;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag("EnemyPlane"))
        {
            Time.timeScale = 0f;
            panelGameOver.SetActive(true);
        }
    }
}
