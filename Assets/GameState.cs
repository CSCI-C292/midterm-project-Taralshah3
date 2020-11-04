using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
    public int lives = 5;
    public int waveNumber = 1;
    public int gold = 150;
    public int goldForKill = 10;
    [SerializeField] GameObject _goldText;
    [SerializeField] GameObject _gameOverText;
    [SerializeField] GameObject _livesText;
    [SerializeField] GameObject _waveText;
    public static GameState Instance;
    bool _isGameOver = false;
    public Button nextWaveButton;
    public GameObject restartButton;

    void Awake() {
        Instance = this;
    }
    void Start()
    {
        this.nextWaveButton.onClick.AddListener(waveFunc);
        this.restartButton.GetComponent<Button>().onClick.AddListener(restartFunc);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lives == 0) {
            //supposed to initiate game over and offer the player the ability to restart
            _isGameOver = true;   
            _gameOverText.SetActive(true);
            restartButton.SetActive(true);
        }
        
    }
    public void restartFunc() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void increaseGold() {
        gold += goldForKill;
        _goldText.GetComponent<Text>().text = "Gold: "  + gold;
    }
    public void decreaseGoldForSingle() {
        gold -= 100;
        _goldText.GetComponent<Text>().text = "Gold: "  + gold;
    }
    public void decreaseGoldForDouble() {
        gold -= 150;
        _goldText.GetComponent<Text>().text = "Gold: "  + gold;
    }
    public void incrementWave() {
        waveNumber += 1;
        _waveText.GetComponent<Text>().text = "Wave: " + waveNumber;
    }
    public bool returnGameOver() {
        return _isGameOver;
    }
    public void decreaseLives() {
        lives -= 1;
        if(lives>=0){
            _livesText.GetComponent<Text>().text = "Lives: "  + lives;
        }
        
    }
    public bool hasGoldForSingle() {
        if(gold>=100) {
            return true;
        }
        else {
            return false;
        }
    }
     public bool hasGoldForDouble() {
        if(gold>=150) {
            return true;
        }
        else {
            return false;
        }
    }
    public void waveFunc() {
        EnemySpawner.Instance.startSpawn();
    }
    
    
}
