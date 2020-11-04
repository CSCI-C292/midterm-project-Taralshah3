using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _enemyPrefab;
    float spawnTime = 2f;
    float spawnX = 0;
    float spawnY = 0;
    int numberSpawned = 0;
    bool canSpawn = true;
    private float speed = 1f;
    public static EnemySpawner Instance;

    void Awake() {
        Instance = this;
    }
    void Start()
    {
        InvokeRepeating("SpawnEnemy",0,spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(numberSpawned >= 10) {
            GameState.Instance.incrementWave();
            //Enemy.Instance.increaseSpeed();
            numberSpawned = 0;
            speed += 1f;
            canSpawn = false;
        }
    }
    void SpawnEnemy() {
        if(canSpawn) {
            GameObject enemy = Instantiate(_enemyPrefab,Camera.main.ViewportToWorldPoint(new Vector3(-8.7f,1.9f,7f)),Quaternion.identity);
            enemy.GetComponent<Enemy>().instantiateSpeed(speed);
            numberSpawned +=1;
        }
            
    }
    public void startSpawn() {
        canSpawn = true;
    }

}
