using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurretClicking : MonoBehaviour
{
    // Start is called before the first frame update
    public Button turretSingle;
    public Button turretDouble;
    bool placeSingleTurret = false;
    bool placeDoubleTurret = false;
    [SerializeField] public GameObject tower1Prefab;
    [SerializeField] public GameObject tower2Prefab; 
    void Start()
    {
        this.turretSingle.onClick.AddListener(clickTurret);
        this.turretDouble.onClick.AddListener(clickDoubleTurret);
    }

    // Update is called once per frame
    void Update()
    {

        if(placeSingleTurret && Input.GetMouseButtonDown(0) && !GameState.Instance.returnGameOver() && GameState.Instance.hasGoldForSingle()) { //detects a click of the mouse
            if(canPlace()) {
                Instantiate(tower1Prefab,Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 100)), Quaternion.identity);
                placeSingleTurret = false;
                GameState.Instance.decreaseGoldForSingle();
            }
        }
        if(placeDoubleTurret && Input.GetMouseButtonDown(0) && !GameState.Instance.returnGameOver() && GameState.Instance.hasGoldForDouble()) {
            if(canPlace()){
                Instantiate(tower2Prefab,Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 90)), Quaternion.identity);
                placeDoubleTurret = false;
                GameState.Instance.decreaseGoldForDouble();
            }
        }
    }
    void clickTurret() {
        placeSingleTurret = true;
        
    }
    void clickDoubleTurret() {
        placeDoubleTurret = true;
    }
    bool canPlace() {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if(hit.collider != null)
        {
            return false;
        }
        else {
            return true;
        }
    }
}
