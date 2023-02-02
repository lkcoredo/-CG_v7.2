using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaleur : MonoBehaviour
{
    public PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
            if (playerInventory.currentTemperature < 100)
            {
                playerInventory.currentTemperature += 0.01;
            }
            
        }
    }
}
