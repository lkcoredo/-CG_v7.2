using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dormir : MonoBehaviour
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
            if (playerInventory.currentEnergie < 100)
            {
                playerInventory.currentEnergie += 0.01;
            }
            
        }
    }
}
