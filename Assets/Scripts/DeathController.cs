using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class DeathController : MonoBehaviour
{


    [SerializeField]
    Canvas DeathUI;

    [SerializeField]
    Text scoreText;

    SessionManager session;


    LevelController Escena;

    private SnakeController Player;

    void Start()
    {
        Escena = GameObject.FindGameObjectWithTag("Change").GetComponent<LevelController>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<SnakeController>();
        session = SessionManager.GetInstancia() as SessionManager;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Body"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (Player != null)
        {
            Player.DeathSnake();
        }


        scoreText.text = string.Format(scoreText.text, session.GetScore().ToString());
        DeathUI.gameObject.SetActive(true);
    }
}
