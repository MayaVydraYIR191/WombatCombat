using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxScore : MonoBehaviour
{
    void Update ()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}

