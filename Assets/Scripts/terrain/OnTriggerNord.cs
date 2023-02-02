using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerNord : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    public bool nordEnter = false;
    public Transform spawnPosTerrainNord;
    public GameObject spawneeGlobeNord;

    //InputDialogue
    bool inputDialogue;

    public static OnTriggerNord current;
    private void Awake()
    {
        current = this;
    }
    public event Action onTriggerEnterNord;
    public void TriggerEnter()
    {
        if (onTriggerEnterNord != null)
        {
            onTriggerEnterNord();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            current.TriggerEnter();
            /*print("Un Objet est rentré dans la zone nord");*/
            nordEnter = true;
            Instantiate(spawneeGlobeNord, spawnPosTerrainNord.position, spawnPosTerrainNord.rotation);
            if (GameObject.Find("SphereSud(Clone)") != null)
                Destroy(GameObject.Find("SphereSud(Clone)"));
            if (GameObject.Find("SphereEst(Clone)") != null)
                Destroy(GameObject.Find("SphereEst(Clone)"));
            if (GameObject.Find("SphereOuest(Clone)") != null)
                Destroy(GameObject.Find("SphereOuest(Clone)"));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inputDialogue == false)
        {
            inputDialogue = true;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputDialogue = false;
        }

        if (Input.GetKeyDown("[8]") && inputDialogue == false)
        {
            current.TriggerEnter();
        }
    }


    void Start()
    {
        inputDialogue = false;
    }
}
