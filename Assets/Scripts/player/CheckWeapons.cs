using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWeapons : MonoBehaviour
{
    private int weaponID;

    public GameObject bodyPart;

    public bool ArmeDeTir = false;
    public bool ArmeDeCombat = false;

    [SerializeField]
    public List<GameObject> weaponList = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount > 0)
        {
            weaponID = gameObject.GetComponentInChildren<ItemOnObject>().item.itemID;
        } 
        else
        {
            weaponID = 0;
            for (int i = 0; i < weaponList.Count; i++)
            {
                weaponList[i].SetActive(false);
            }
        }

        if(bodyPart.transform.childCount >1)
        {
            for(int i = 0; i < weaponList.Count; i++)
            {
                weaponList[i].SetActive(false);
            }
        }

        //epee en fer
        if(weaponID == 1 && transform.childCount > 0)
        {
            for(int i = 0; i < weaponList.Count; i++)
            {
                if(i == 0)
                {
                    weaponList[i].SetActive(true);
                    ArmeDeTir = false;
                    ArmeDeCombat = true;
                }
            }
        }

        //arbalète
        if (weaponID == 2 && transform.childCount > 0)
        {
            for (int i = 1; i < weaponList.Count; i++)
            {
                if (i == 1)
                {
                    weaponList[i].SetActive(true);
                    ArmeDeTir = true;
                    ArmeDeCombat = false;
                }
            }
        }
    }
}
