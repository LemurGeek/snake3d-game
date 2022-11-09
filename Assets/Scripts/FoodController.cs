using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodController : MonoBehaviour
{
    [SerializeField]

    CollectibleTypes collectibleType;

    [SerializeField]
    float collectibleValue = 2.0F;

    [SerializeField]
    float lifeTime = 10.0F;

    [SerializeField]
    float expireValue = -1.0F;

    bool isExpired = true;

    GameObject player;
    SessionManager session;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        Destroy(gameObject, lifeTime);
        session = SessionManager.GetInstancia() as SessionManager;
    }

    private void Update()
    {
        this.transform.Rotate(0f, 10f * Time.deltaTime, 0f, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isExpired = false;
            Destroy(gameObject);

            //Igualmente me gustaria cambiar el nombre a Rock o Obstacle
            if (this.collectibleType.ToString().Equals("POISON"))
            {
                session.AddScore(expireValue);
            }

            //Me gustaria cambiar el nombre a food o apple
            if (this.collectibleType.ToString().Equals("COLLECTIBLE"))
            {
                session.AddScore(collectibleValue);
                player.GetComponent<SnakeController>().GrowSnake();
            }
        }
    }
}
