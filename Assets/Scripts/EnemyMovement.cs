using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private GameManager gameManager;

    [HideInInspector] public float speed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void Update()
    {
        this.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(player.tag))
        {
            //Trigger Gameover
            gameManager.ShowGameOver();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.score += 1;
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
