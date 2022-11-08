using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5.0F;

    [SerializeField]
    float bodySpeed = 5.0F;

    [SerializeField]
    GameObject bodyPrefab;

    [SerializeField]
    int gap = 100;

    [SerializeField]
    int bodyPartAmount = 5;

    Rigidbody rb;

    float xDirection;

    List<GameObject> bodyParts = new List<GameObject>();
    List<Vector3> positionHistory = new List<Vector3>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        for (int i = 0; i < bodyPartAmount; i++)
        {
            GrowSnake();
        }
    }

    void Update()
    {
        xDirection = Input.GetAxisRaw("Horizontal");
        
        rb.transform.position += rb.transform.forward * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Horizontal"))
        {
            rb.transform.Rotate(0, 90 * xDirection, 0);
        }

        positionHistory.Insert(0, rb.transform.position);

        int index = 0;
        foreach(var body in bodyParts)
        {
            Vector3 point = positionHistory[Mathf.Min(index * gap, positionHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * bodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }
    }
    void GrowSnake()
    {
        GameObject body = Instantiate(bodyPrefab);
        bodyParts.Add(body);
    }
}
