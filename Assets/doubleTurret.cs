using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleTurret : MonoBehaviour
{
    [SerializeField] GameObject _rocketPrefab;
    float rocketSpawnTime = 2f;
    private EnemySpawner enemySpawner;
    private List<GameObject> enemyList = new List<GameObject>();
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
        minDistance = 99999;
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

        }
    }
    void SpawnRocket() {
        if(!(enemyList.Count == 0) && minDistance < 10) {
            Instantiate(_rocketPrefab,new Vector3(transform.position.x-0.1f,transform.position.y,-50),Quaternion.identity);
            Instantiate(_rocketPrefab,new Vector3(transform.position.x+0.1f,transform.position.y,-50),Quaternion.identity);
        }
        else {
        }
        
    }
}
