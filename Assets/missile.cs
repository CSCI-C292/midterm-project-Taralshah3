using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    // Start is called before the first frame update
    float _speed = 2f;
    [SerializeField] GameObject _gameState;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, Time.deltaTime * _speed, 0);
    }
    void OnTriggerEnter2D(Collider2D collider) {
        Destroy(gameObject);
        Destroy(collider.gameObject);
        GameState.Instance.increaseGold();
    }
}
