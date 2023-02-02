using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereHit : MonoBehaviour
{
    PlayerInventory playerInv;

    // Start is called before the first frame update
    void Start()
    {
        playerInv = gameObject.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("this is triggering");
        print("hello !");
/*        RaycastHit hit;

        if (hit.transform.tag == "vivant")
        {
            hit.transform.GetComponent<enemyAI>().ApplyDamage(playerInv.currentDamage);
        }*/
    }
}
