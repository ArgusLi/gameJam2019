using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endScore : MonoBehaviour
{
    public TextMeshProUGUI tm;
    private float deltaTime;

    void OnEnable()
    {
        deltaTime = PlayerPrefs.GetFloat("score");
        int score = (int)deltaTime;
        tm.SetText("Score: " + score.ToString());
    }
}
