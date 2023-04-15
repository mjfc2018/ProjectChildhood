using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ZenvaVR;


public class GameController : MonoBehaviour
{

    //[SerializeField]
    //ObjectPool enemySpawn;

    [SerializeField]
    Text scorePanel;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject enemyInstance = enemySpawn.GetObj ();
        //enemyInstance.GetComponent<MoveEnemyAirPlane> ().OnKill += OnEnemyKill;
    }

    void OnKill()
    {
        score += 25;
        scorePanel.text = "Score: " + score;
    }
}
