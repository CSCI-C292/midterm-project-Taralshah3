using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _enemyPrefab2;
    float spawnTime = 2f;
    float spawnX = 0;
    float spawnY = 0;
    int numberSpawned = 0;
    bool canSpawn = true;
    private float speed = 1f;
    public static EnemySpawner Instance;
    public List<GameObject> enemyList = new List<GameObject>(); 
    public GameState gs;
    public static int sizeOfWave = 10;
    public int numberEnemyOne = 8;
    

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
        //ends the wave
        if(numberSpawned >= sizeOfWave) {
            GameState.Instance.incrementWave();
            sizeOfWave +=1;
            //Enemy.Instance.increaseSpeed();
            numberSpawned = 0;
            //increases speed
            //speed += 1f;
            canSpawn = false;
        }
        
    }
    void SpawnEnemy() {
        //for the first enemy
        if(canSpawn && numberSpawned < 9) {
            GameObject enemy = Instantiate(_enemyPrefab,Camera.main.ViewportToWorldPoint(new Vector3(-8.7f,1.9f,7f)),Quaternion.identity);
            enemy.GetComponent<Enemy>().instantiateSpeed(speed);
            numberSpawned +=1;
            enemyList.Add(enemy);
        }
        else if(canSpawn) { 
                GameObject enemy2 = Instantiate(_enemyPrefab2,Camera.main.ViewportToWorldPoint(new Vector3(-8.7f,1.9f,7f)),Quaternion.identity);
                enemy2.GetComponent<Enemy>().instantiateSpeed(speed*2);
                enemy2.GetComponent<Enemy>().instantiateLives(2);
                numberSpawned +=1;
                enemyList.Add(enemy2);
                //enemyList.Add(enemy2);
        }  
            
    }
    public List<GameObject> getEnemyList() {
        return enemyList;
    }
    public void startSpawn() {
        canSpawn = true;
    }
    public void removeElementFromList(GameObject enemyObject) {
        enemyList.Remove(enemyObject);
    }
    public void addToEnemyList(GameObject enemyObject) {
        enemyList.Add(enemyObject);
    }
    public void clearEnemyList() {
        Debug.Log(enemyList.Count);
        for(int i = 0; i < enemyList.Count;  i++) {
            Destroy(enemyList[i]);
        }
        enemyList.Clear();
        Debug.Log(enemyList.Count);
    }

}
