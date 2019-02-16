using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScore : MonoBehaviour
{
    public TextMesh tm;
    private float deltaTime;

    void OnEnable()
    {
        deltaTime = PlayerPrefs.GetFloat("score");
        tm = (TextMesh)GameObject.Find("nameOfTheObject").GetComponent<TextMesh>();
        int score = (int)deltaTime;
        tm.text = "Score: " + score;
    }


}
