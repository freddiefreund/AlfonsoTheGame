using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnIntervall;
    private float timer;
    [SerializeField] private List<Transform> RouteA;
    [SerializeField] private List<Transform> RouteB;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private int numberOfRoutes;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnEnemy();
            timer = spawnIntervall;
        }
    }

    private int randomRouteNumber;
    private List<Transform> randomRoute;
    private GameObject createdEnemy;
    private EnemyNavigation enemyScript;
    private void SpawnEnemy()
    {
        randomRouteNumber = Random.Range(0, numberOfRoutes);
        switch (randomRouteNumber)
        {
           case 0: randomRoute = RouteA;
               break;
           case 1: randomRoute = RouteB;
               break;
        }
        if (EnemyPrefab != null)
        {
            createdEnemy = Instantiate(EnemyPrefab, randomRoute[0].position, Quaternion.identity);
            enemyScript = createdEnemy.GetComponent<EnemyNavigation>();
            enemyScript.SetWaypointList(randomRoute);
        }
    }
}
