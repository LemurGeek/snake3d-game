using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{


    [SerializeField]
    Canvas DeathUI;

    LevelController Escena;

    private SnakeController Player;

    void Start()
    {
        Escena = GameObject.FindGameObjectWithTag("Change").GetComponent<LevelController>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<SnakeController>();
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

    void GameOver() {
        if (Player != null) {
            Player.DeathSnake();
        }
        DeathUI.gameObject.SetActive(true);
    }
}
