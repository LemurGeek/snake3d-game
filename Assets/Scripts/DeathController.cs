using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class DeathController : MonoBehaviour
{


    [SerializeField]
    Canvas DeathUI;

    [SerializeField]
    TextMeshProUGUI score;


    [SerializeField]
    TextMeshProUGUI finalscore;


    SessionManager session;




    LevelController Escena;

    private SnakeController Player;

    void Start()
    {
        
        Escena = GameObject.FindGameObjectWithTag("Change").GetComponent<LevelController>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<SnakeController>();
        session = SessionManager.GetInstancia() as SessionManager;
    }


    private void Update()
    {
        score.text = session.GetScore().ToString();
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


        finalscore.text = session.GetScore().ToString();
        DeathUI.gameObject.SetActive(true);
    }


}
