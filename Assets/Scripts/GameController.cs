using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject asteroid;
    public Vector2 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public TextMesh scoreText;
    public TextMesh gameOverText;
    public TextMesh restartText;

    private int score;
    private bool gameOver;
    private bool restart;

	// Use this for initialization
	void Start () {
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
	}

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Application.LoadLevel("gameScene"); deprecated
                // Application.LoadLevel(Application.loadedLevel); deprecated 
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reload current scene
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
    
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for(int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y));
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(asteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press R to restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
