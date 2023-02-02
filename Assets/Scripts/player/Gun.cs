using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 100f;
    public float range = 100f;
    public Camera fpsCam;

    public CheckWeapons a;

    PlayerInventory playerInv;

    void Start()
    {
        playerInv = gameObject.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        //RETABLIR
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            a = FindObjectOfType<CheckWeapons>();
            if (a != null)
            {
                if (a.ArmeDeTir == true)
                {
                    Shoot();
                }
            }
            else
            {
                //Debug.Log(" le personnage ne porte rien");
            }
            
        }
        //RETABLIR
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            
            

            if (hit.transform.tag == "team1")
            {
                hit.transform.GetComponent<AITeam1>().ApplyDamage(playerInv.currentDamage);
            }

            if (hit.transform.tag == "team2")
            {
                hit.transform.GetComponent<AITeam2>().ApplyDamage(playerInv.currentDamage);
            }

            if (hit.transform.tag == "hostile")
            {
                hit.transform.GetComponent<HostileToPlayer>().ApplyDamage(playerInv.currentDamage);
            }


        }
    }
}
