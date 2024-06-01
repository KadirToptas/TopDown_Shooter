using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Controller : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform[] spawnPoints;

    public float interval;
    void Start()
    {
        InvokeRepeating("Spawn",0.5f,interval);
    }

    private void Spawn()
    {
        int randPos = Random.Range(0,spawnPoints.Length);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[randPos].position, Quaternion.identity);
        
    }
}
