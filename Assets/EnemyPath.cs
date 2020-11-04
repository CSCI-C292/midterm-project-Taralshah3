using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3[] boardPos;
    void Start()
    {
        //children = max amount
        int numberChildren = this.transform.childCount;
        boardPos = new Vector3[numberChildren];
        for(int i = 0; i < numberChildren; i++) {
            Vector3 currentPos = this.transform.GetChild(i).gameObject.transform.position;
            boardPos[i] = currentPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3[] getArray() {
        return boardPos;
    }
}
