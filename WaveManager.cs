using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaveManager : MonoBehaviour
{
    GameObject[] EnemyCount;
    int currentEnemyNumber;
    int newEnemyNumber;

    float randomEnemyIndex;

    public GameObject target;

    void Start()
    {
        
    }

    void Update()
    {
        //EnemyManager();
    }

    void EnemyManager()
    {
        EnemyCount = GameObject.FindGameObjectsWithTag("Enemy");
        currentEnemyNumber = EnemyCount.Length;

        //Triggers function to spawn enemies.
        for( int i = 3; i <= 3; i-- )
        {
            randomEnemyIndex = Random.Range(0, currentEnemyNumber);
            StartCoroutine("SendWaveTimer");
        }
    }

    IEnumerator SendWaveTimer()
    {
        yield return new WaitForSeconds(30f);
        SendEnemy();
    }

    void SendEnemy()
    {
        //Converts randomEnemyIndex to int, then modifies static variables.
        randomEnemyIndex = Mathf.Ceil(randomEnemyIndex);
        int randomenemyindex = (int)randomEnemyIndex;

        NavMeshAgent Enemy;

        Enemy = EnemyCount[randomenemyindex].GetComponent<NavMeshAgent>();
        Enemy.SetDestination(target.transform.position);
    }

    //For loop that fills array of enemies
    //For loop that calls function 3x, tells 3 random anemies to atack
    //for loop with index of 3, decrements
    //randomRange
    //for loop calls function to tell enemy to pursue player
}
