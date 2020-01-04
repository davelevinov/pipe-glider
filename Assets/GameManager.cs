using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int numberOfPlatforms;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverPanel;
    
    public int _score, _highscore;
    
    private void AddScore()
    {
        _score++;

        if (_score > _highscore)
        {
            _highscore = _score;
        }

        RefreshScoreText();
    }

    private void RefreshScoreText()
    {
        bool hasWonGame = (numberOfPlatforms == _score);

        if(hasWonGame)
        {
            scoreText.fontSize = 20;
            scoreText.text = "YOU WON";
        }
            else
        { 
       
        scoreText.text = _score.ToString();
        highScoreText.text = _highscore.ToString();
        }
    }
    
    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        Debug.Log("Game Over");
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void LevelComplete()
    {
        Debug.Log("Level complete");
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        RefreshScoreText();
        BallController.PassPlatform += OnPassPlatform;
        BallController.HitGoal += OnHitGoal;
        BallController.KillBall += OnKillBall;
    }

    private void OnKillBall(BallController obj)
    {
        Destroy(obj.gameObject);
        GameOver();
    }

    private void OnHitGoal()
    {
        LevelComplete();
    }

    private void OnDestroy()
    {
        BallController.PassPlatform -= OnPassPlatform;
        BallController.HitGoal -= OnHitGoal;
        BallController.KillBall -= OnKillBall;
    }

    private void OnPassPlatform(Transform obj)
    {
        AddScore();
        updateDisabledPlatforms();
            //Debug.Log("the object that triggered" + obj.name);


    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void updateDisabledPlatforms()
    {
        string obstaclePrefix = "Obstacle ";
        bool isFirstObstacle = (_score == 0);
        GameObject obstacleToDisable;
        if (!isFirstObstacle)
        {
            int previousObstacleNumber = _score - 1;
            obstacleToDisable = GameObject.Find(obstaclePrefix + previousObstacleNumber);
            obstacleToDisable.SetActive(false);
            Debug.Log(""+obstaclePrefix + previousObstacleNumber + " is dissabled");

        }
    }


}
