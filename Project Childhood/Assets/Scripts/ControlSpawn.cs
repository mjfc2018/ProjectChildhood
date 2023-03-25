using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpawn : MonoBehaviour
{
    public float interval;
    public GameObject prefab;
    public Transform[] positions;

    float timeControl = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        timeControl += Time.deltaTime;

        if(timeControl >= interval) {
            timeControl = 0;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int random = Random.Range(0, positions.Length);
        Instantiate(prefab, positions[random].position, Quaternion.Euler(0, 0, -90f));
    }
}
