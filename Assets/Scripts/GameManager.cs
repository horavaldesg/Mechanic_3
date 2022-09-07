using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemy;
    [SerializeField] private float spawnRate;
    [SerializeField] private float enemySpeed;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOver;

    [HideInInspector] public int score;
    private float t;
    private int amountOfRounds;


    void Update()
    {
        scoreText.SetText(score.ToString("Score: ##"));

        t += Time.deltaTime;
        
        if(t > spawnRate)
        {
            if (amountOfRounds % 5 == 0 && amountOfRounds != 0)
            {
                enemySpeed += 1;
            }
            GameObject instEnemy = Instantiate(enemy, spawnPoints[RandomNumber()]);
            instEnemy.GetComponent<EnemyMovement>().speed = enemySpeed;
            amountOfRounds++;
            t = 0;

        }
    }

    private int RandomNumber()
    {
        return Random.Range(0, spawnPoints.Length);
    }
    public void ShowGameOver()
    {
        gameOver.enabled = true;
        Time.timeScale = 0;
    }

}
