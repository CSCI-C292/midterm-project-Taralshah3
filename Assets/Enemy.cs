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
    [SerializeField] GameObject _gameState;
    public static Enemy Instance;
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
                Destroy(this);
                GameState.Instance.decreaseLives();
            }
            time = 0;
        }
    }
    public void instantiateSpeed(float speed2) {
        this.speed = speed2;
    }

    
}
