using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlSpawn : MonoBehaviour
{

    [SerializeField]
    float enemyInterval;

    [SerializeField]
    float fuelInterval;

    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    GameObject fuelPrefab;

    [SerializeField]
    Transform[] positions;

    float timeEnemyControl = 0;
    float timeFuelControl = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        SpawnFuel();
    }

    // Update is called once per frame
    void Update()
    {
        timeEnemyControl += Time.deltaTime;
        timeFuelControl += Time.deltaTime;

        if (timeEnemyControl >= enemyInterval) {
            timeEnemyControl = 0;
            SpawnEnemy();
        }

        if (timeFuelControl >= enemyInterval)
        {
            timeFuelControl = 0;
            SpawnFuel();
        }
    }

    void SpawnEnemy()
    {
        int random = Random.Range(0, positions.Length);
        
        GameObject enemy = Instantiate(enemyPrefab, positions[random].position, Quaternion.Euler(0, 0, -90f));
        Destroy(enemy, 15f);
    }

    void SpawnFuel()
    {
        int random = Random.Range(0, positions.Length);

        GameObject enemy = Instantiate(fuelPrefab, positions[random].position, Quaternion.Euler(0, 0, 0));
        Destroy(enemy, 15f);
    }
}
