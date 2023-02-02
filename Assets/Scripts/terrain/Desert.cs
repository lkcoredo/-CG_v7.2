using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desert : MonoBehaviour
{
    public PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInventory.currentSoif -= 0.01;
        playerInventory.currentTemperature += 0.01;
    }
}
