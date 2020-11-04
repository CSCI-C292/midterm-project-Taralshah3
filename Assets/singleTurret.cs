using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleTurret : MonoBehaviour
{
    [SerializeField] GameObject _rocketPrefab;
    float rocketSpawnTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRocket",0,rocketSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRocket() {
        Instantiate(_rocketPrefab,new Vector3(transform.position.x,transform.position.y,-50),Quaternion.identity);
    }
}
