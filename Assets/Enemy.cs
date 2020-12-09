using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3[] boardPos;
    private int pos = 0;
    private Vector3 currentTarget;
    private float time = 0f;
    private float speed = 1f;
    public static Enemy Instance;
    private float numberLives = 1;
    void Awake() {
        Instance = this;
    }
    void Start()
    {
        boardPos = GameObject.FindWithTag("Pathway").GetComponent<EnemyPath>().getArray();
        currentTarget = boardPos[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTarget != this.transform.position) {
            Vector3 temp;
            time += Time.deltaTime*speed;
            temp = Vector3.Lerp(boardPos[pos],boardPos[pos+1],time); //deltaTime determines how close we are from transformpos to  currentTarget
            this.transform.position = temp;
        }
        if(this.transform.position == boardPos[pos+1]) {
            pos += 1;
            if(pos >= boardPos.Length-1) {
                GameObject enemySpawner2 = GameObject.FindWithTag("Spawner");
                EnemySpawner enemySpawner = enemySpawner2.GetComponent<EnemySpawner>();
                enemySpawner.removeElementFromList(this.gameObject);
                Destroy(this);
                GameState.Instance.decreaseLives();
            }
            time = 0;
        }

    }
    public void instantiateSpeed(float speed2) {
        this.speed = speed2;
    }
    public void instantiateLives(float lives2) {
        this.numberLives = lives2;
    }
    public void reduceLivesByOne() {
        this.numberLives-=1;
        if(this.numberLives == 1) {
            this.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
    public float getNumberLives() {
        return this.numberLives;
    }

    
}
