using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerOuest : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    public bool ouestEnter = false;
    public Transform spawnPosTerrainOuest;
    public GameObject spawneeGlobeOuest;

    //InputDialogue
    bool inputDialogue;

    public static OnTriggerOuest current;
    private void Awake()
    {
        current = this;
    }
    public event Action onTriggerEnterOuest;
    public void TriggerEnter()
    {
        if (onTriggerEnterOuest != null)
        {
            onTriggerEnterOuest();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            current.TriggerEnter();
            /*print("Un Objet est rentré dans la zone ouest");*/
            /*myMaterial.color = Color.green;*/
            ouestEnter = true;
            Instantiate(spawneeGlobeOuest, spawnPosTerrainOuest.position, spawnPosTerrainOuest.rotation);
            if (GameObject.Find("SphereNord(Clone)") != null)
                Destroy(GameObject.Find("SphereNord(Clone)"));
            if (GameObject.Find("SphereEst(Clone)") != null)
                Destroy(GameObject.Find("SphereEst(Clone)"));
            if (GameObject.Find("SphereSud(Clone)") != null)
                Destroy(GameObject.Find("SphereSud(Clone)"));
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

        if (Input.GetKeyDown("[4]") && inputDialogue == false)
        {
            current.TriggerEnter();
        }
    }


    void Start()
    {
        inputDialogue = false;
    }
}
