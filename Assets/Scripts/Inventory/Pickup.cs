using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;
    //public AudioClip pickSound;
    //private AudioSource source;
    public GameObject image;
    public int itemCount;
    
  

    //void Awake()
    //{
     //   source = GetComponent<AudioSource>();
    //}

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        itemCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    itemCount += 1;
                    //Slot.itemnum.text = itemCount.ToString();
                    // source.PlayOneShot(pickSound, 1F);
                    //inventory.isFull[i] = true;
                    Instantiate(slotButton, inventory.slots[i].transform);
                    image.SetActive(false);
                    break;
                }
            }
        }
    }

    public void isStackable()
    {
    }
}

