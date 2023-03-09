using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> SpawnableObject;
    [SerializeField] private float spawnRate = 1.0f;
    public int lives = 3;
    private int score;
    public TextMeshProUGUI scoreText, gameOver, livesText;
    public Button restartButton, easyButton, medButton,hardButton;
    public GameObject titleScreen;
    

    // Start is called before the first frame update
    void Start()
    {
        gameOver.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        titleScreen.SetActive(true);
        //StartCoroutine(SpawnTarget());
        UpdateScore(0);
        livesText.text = "Lives: " + lives;
    }
    private void Update()
    {
        if(lives <= 0)
        {
            gameOver.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    IEnumerator SpawnTarget()
    {
        while (lives > 0)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject spawn = SpawnableObject[UnityEngine.Random.Range(0, SpawnableObject.Count)];
            Instantiate(spawn);
        }
    }
    public void UpdateScore(int score)
    {
        this.score += score;
        scoreText.text = "Score: " + this.score;
    }
    public void LoseALife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SetToEasy()
    {
        spawnRate = 1f;
        StartGame();
    }
    public void SetToMedium() 
    {
        spawnRate =.6f;
        StartGame();
    }

    public void SetToHard()
    {
        spawnRate = .3f;
        StartGame();
    }
    private void StartGame()
    {
        titleScreen.SetActive(false);
        StartCoroutine(SpawnTarget());
    }
}
