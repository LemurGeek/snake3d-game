using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : Singleton<SessionManager>
{

    [SerializeField]
    float score;

    void Start()
    {

    }

    void Update()
    {

    }


    public void AddScore(float value)

    {
        score += value;
    }

    public float GetScore()
    {
       
       return score;
    }

    public void ResetScore()
    {
        score = 0;
    }

}
