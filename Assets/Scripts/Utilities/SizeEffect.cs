using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeEffect : MonoBehaviour
{

    /*SCRIPT CREADO 100% POR EL ESTUDIANTE IAN FALLAS :) 
     */

    [SerializeField]
    [Range(1.2f, 1.5f)]
    float maxSize;

    [SerializeField]
    [Range(0.05f, 2f)]
    float effectorValue;

    [SerializeField]
    float currentSize;
    
    float minSize = 1f;

    int state = 0;

    void Start()
    {
        currentSize = 1f;
    }

    void Update()
    {
        if (state == 0) {
            currentSize -= effectorValue * Time.deltaTime;
            if (currentSize <= minSize) {
                state = 1;
            }
        }
        else {
            currentSize += effectorValue * Time.deltaTime;
            
            if (currentSize >= maxSize) {
                state = 0;
            }
        }

        transform.localScale = new Vector3(currentSize, currentSize, currentSize);
    }
}
