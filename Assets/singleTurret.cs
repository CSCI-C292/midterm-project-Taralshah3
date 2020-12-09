﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleTurret : MonoBehaviour
{
    [SerializeField] GameObject _rocketPrefab;
    private List<GameObject> enemyList = new List<GameObject>();
    private EnemySpawner enemySpawner;
    float rocketSpawnTime = 2f;
    float minDistance = 10000000000;
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemySpawner2 = GameObject.FindWithTag("Spawner");
        enemySpawner = enemySpawner2.GetComponent<EnemySpawner>();
        InvokeRepeating("SpawnRocket",0,rocketSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        enemyList = enemySpawner.getEnemyList();
        if(!(enemyList.Count == 0)) {
            GameObject enemy3 = enemyList[0];
            //float minDistance = 10000000000;
            GameObject minDistanceObject = enemyList[0];
            //calculate min distance
            for(int i = 0; i < enemyList.Count; i++) {
                GameObject currentEnemy = enemyList[i];  
                float currentDistance = (currentEnemy.transform.position-gameObject.transform.position).magnitude;
                if(currentDistance < minDistance) {
                    minDistanceObject = enemyList[i];
                    minDistance = currentDistance;
                }

            }
            enemy3 = minDistanceObject;
            //transform.right = enemy3.transform.position - transform.position;
            gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, enemy3.transform.position - gameObject.transform.position);
            //look up 2d joystick games handle firing of the bullets 

        }
    }
    void SpawnRocket() {
        if(!(enemyList.Count == 0)) {
            if(!(enemyList.Count == 0) && minDistance < 4) {
                Instantiate(_rocketPrefab,new Vector3(transform.position.x,transform.position.y,-50),Quaternion.identity);
            }
            else {
            }
            //Instantiate(_rocketPrefab,new Vector3(transform.position.x,transform.position.y,-50),Quaternion.identity);
        }
    }
}
