using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    public void UpdateScore()
    {
        GetComponent<TextMeshProUGUI>().text = "Score: " + FindObjectOfType<ScoreCounter>().curScore.ToString();
    }

    void Update()
    {
        UpdateScore();
    }
}
