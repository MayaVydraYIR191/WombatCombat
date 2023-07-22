using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Timer : MonoBehaviour
{
public float timeStart = 180;

public Text textTimer;
public GameObject timerobj;
public GameObject timezombie;

public GameObject enemy;
// Start is called before the first frame update
    void Start()
    {
        textTimer.text = timeStart.ToString();
        Apocalypse();
    }
    
    void Update()
    {
        timeStart -= Time.deltaTime;
        textTimer.text = Mathf.Round(timeStart).ToString();
        if (timeStart<=0)
        {
            timerobj.SetActive(false);
            timezombie.SetActive(true);
        }

    }

    async void Apocalypse()
    {
        await Task.Delay(TimeSpan.FromSeconds(timeStart));
            timeStart = 0;
            StartCoroutine(Spawn());
    }

    IEnumerator Spawn ()
    {
        while (!playermove.lose)
        {
            Instantiate(enemy, new Vector2(Random.Range(-30f, 30f),0.06f ), Quaternion.identity);
            yield return new WaitForSeconds(0.8f);
        }
    }

}
