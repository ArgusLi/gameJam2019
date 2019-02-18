using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class leaderboardScores : MonoBehaviour
{
    public TextMeshProUGUI[] tm = new TextMeshProUGUI[10];
    private float deltaTime;
    private string player;
    private char[] alphabet = new char[53];
    private int[] localscore = new int[11];
    private string[] localname = new string[11];

    private void OnEnable()
    {
        bool flag = false;
        string alphabetString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
        alphabet = alphabetString.ToCharArray();

        deltaTime = PlayerPrefs.GetFloat("score");
        player = PlayerPrefs.GetString("playername");
        int score = (int)deltaTime;
        localscore[10] = 0;

        for (int i = 0; i<10; i++)
        {
            localname[i] = PlayerPrefs.GetString("playernames"+i);
            localscore[i] = PlayerPrefs.GetInt("playerscores" + i);
            if (localscore[i] < score && localscore[i + 1] < score && flag == false)
            {
                localname[i] = player;
                localscore[i] = score;
                flag = true;
            }
        }
        for (int i = 0; i < 10; i++)
        {
            tm[i].SetText("Player:" + localname[i] +", "+ " highscore: " + localscore[i]);
            PlayerPrefs.SetString("playernames" + i, localname[i]);
            PlayerPrefs.SetInt("playerscores" + i, localscore[i]);
        }
    }

}
