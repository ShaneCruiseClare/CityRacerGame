using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public bool gameOver = false;
    private float spawnRange = 7;
    private float startDelay = 1;
    private float spawnInterval = 1f;
    private PlayerController playerControllerScript;

    public Button restartButton;
    //score Varaibles
    private int score;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOverText;


    // Start is called before the first frame update
    void Start()
    {
     
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Car").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        UpdateScore(0);
        
    }

    void SpawnRandomObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            UpdateScore(1);
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0, 25);
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        }
        else if (playerControllerScript.gameOver == true)
        {
            GameOver();
        }
        
    }
}
