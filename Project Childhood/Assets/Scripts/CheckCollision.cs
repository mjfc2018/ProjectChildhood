using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    
    [SerializeField]
    GameObject _panelGameOver;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag("EnemyPlane"))
        {
            Time.timeScale = 0f;
            _panelGameOver.SetActive(true);
        }
    }
}
