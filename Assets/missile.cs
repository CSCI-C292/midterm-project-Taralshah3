using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    // Start is called before the first frame update
    float _speed = 6f;
    private List<GameObject> enemyList = new List<GameObject>();
    private EnemySpawner enemySpawner;
    [SerializeField] GameObject _gameState;
    GameObject enemy3;
    Vector3 enemy3Pos;
    private float time = 0f;
    void Start()
    {
        //changes rotation of the missile 
        GameObject enemySpawner2 = GameObject.FindWithTag("Spawner");
        enemySpawner = enemySpawner2.GetComponent<EnemySpawner>();
        enemyList = enemySpawner.getEnemyList();


        if(!(enemyList.Count == 0)) {
            GameObject enemy3 = enemyList[0];
            float minDistance = 10000000000;
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
            Debug.Log(minDistance);
            enemy3 = minDistanceObject;
            enemy3Pos = enemy3.transform.position;
            gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, enemy3.transform.position - gameObject.transform.position);
            
            //look up 2d joystick games handle firing of the bullets 

        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime*_speed/500;
        //this.transform.position = Vector3.Lerp(transform.position, enemy3Pos*2,time); //enemy3Pos*2

        Vector3 rotationDirection = this.transform.rotation*Vector3.up;
        this.transform.position += rotationDirection*10*Time.deltaTime;

        //used to change the rotation of the missile
        //transform.position += new Vector3(0, Time.deltaTime * _speed, 0);

    }
    void OnTriggerEnter2D(Collider2D collider) {
        GameObject enemySpawner2 = GameObject.FindWithTag("Spawner");
        EnemySpawner enemySpawner = enemySpawner2.GetComponent<EnemySpawner>();
        Destroy(gameObject);

        collider.gameObject.GetComponent<Enemy>().reduceLivesByOne();
        if(collider.gameObject.GetComponent<Enemy>().getNumberLives() <= 0) {
            Destroy(collider.gameObject);
            enemySpawner.removeElementFromList(collider.gameObject);
        }
        
        GameState.Instance.increaseGold();
    }
}
