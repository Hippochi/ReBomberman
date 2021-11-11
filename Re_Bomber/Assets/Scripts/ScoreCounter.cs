using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreCounter : MonoBehaviour
{

    public int curScore;
    public static ScoreCounter instance;
    void Awake()
    {
        curScore = 0;
        instance = this;
        int sessionCount = FindObjectsOfType<ScoreCounter>().Length;
        if (sessionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
