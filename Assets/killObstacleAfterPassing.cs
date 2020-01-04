using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOvstacle2 : MonoBehaviour
{

    public GameManager currentGameManagerr;
    
    string obstaclePrefixx = "Obstacle ";
    // Start is called before the first frame update
    void Start()
    {
        //currentGameManager = GetComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        int currentScore = currentGameManagerr._score;
        Debug.Log(currentGameManagerr._score);
        bool isFirstObstacle = (currentScore == 0);
        GameObject obstacleToDisable;
        if (!isFirstObstacle)
        {
            int previousObstacleNumber = currentScore - 1;
            obstacleToDisable = GameObject.Find(obstaclePrefixx + previousObstacleNumber);
            obstacleToDisable.SetActive(false);
            Debug.Log(obstaclePrefixx + previousObstacleNumber + " is dissabled");

        }

    }
}
