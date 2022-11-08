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
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isExpired = false;
            Destroy(gameObject);

            //Igualmente me gustaria cambiar el nombre a Rock o Obstacle
            if (this.collectibleType.ToString().Equals("POISON")) {
                //Remover Puntaje Marcador
            }

            //Me gustaria cambiar el nombre a food o apple
            if (this.collectibleType.ToString().Equals("COLLECTIBLE"))
            {
                //Agregar Puntaje Marcador
                //codigo
                player.GetComponent<SnakeController>().GrowSnake();
            }
        }
    }
}
