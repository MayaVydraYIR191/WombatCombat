using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeHealth : MonoBehaviour
{
 public int healthOfCube = 5;
 void Update()
    {
        if (healthOfCube <= 0)
        {
            gameObject.SetActive(false);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            healthOfCube -=1;
        }
    }
}
