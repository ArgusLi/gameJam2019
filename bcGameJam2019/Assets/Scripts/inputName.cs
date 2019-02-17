using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inputName : MonoBehaviour
{
    public TextMeshProUGUI tm;
    private string playername;
    // Start is called before the first frame update

    void OnDisable()
    {
        PlayerPrefs.SetString("playername", playername);
    }
}
