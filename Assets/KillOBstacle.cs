using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOvstacle : MonoBehaviour
{

    public GameManager currentGameManager;
    string obstaclePrefix ="Obstacle ";
    // Start is called before the first frame update
    void Start()
    {
        //currentGameManager = GetComponent<GameManager>();

         
    }

    // Update is called once per frame
    void Update()
    {
        int currentScore = currentGameManager._score;
        Debug.Log(currentGameManager._score);
        bool isFirstObstacle = (currentScore == 0);
        GameObject obstacleToDisable;
        if(!isFirstObstacle)
        {
            int previousObstacleNumber = currentScore-1;
            obstacleToDisable = GameObject.Find(obstaclePrefix + previousObstacleNumber);
            obstacleToDisable.SetActive(false);
            Debug.Log(obstaclePrefix + previousObstacleNumber + " is dissabled");

        }

    }
}
