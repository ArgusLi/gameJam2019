using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class leaderboardScores : MonoBehaviour
{
    public TextMeshProUGUI[] tm = new TextMeshProUGUI[10];
    private string[] leaderboard = new string[11];
    private float deltaTime;
    private string player;
    private char[] alphabet = new char[53];
    private int[] localscore = new int[11];

    private void OnEnable()
    {

        string alphabetString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
        alphabet = alphabetString.ToCharArray();

        deltaTime = PlayerPrefs.GetFloat("score");
        player = PlayerPrefs.GetString("playername");
        int score = (int)deltaTime;
        localscore[10] = 0;
        //test
        player = "colegreer";
        //score = 5;

        //test end
        //test end
        for (int i = 0; i<10; i++)
        {

            leaderboard[i] = tm[i].text;
            leaderboard[i].Trim(alphabet);
            bool success = Int32.TryParse(tm[i].text, out localscore[i]);
            if (success == false) { localscore[i] = 0; }
        }
        for (int i = 0; i < 10; i++)
        {
            if(localscore[i] <= score && localscore[i+1] < score)
            {
                tm[i].SetText(player + " highscore: " + score.ToString());
                break;
            }

        }
    }


}
