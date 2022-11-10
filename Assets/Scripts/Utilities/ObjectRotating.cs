using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotating : MonoBehaviour
{
    
    void Update()
    {
        transform.Rotate(0f, 1 * Time.deltaTime, 0f, Space.Self);    
    }
}
