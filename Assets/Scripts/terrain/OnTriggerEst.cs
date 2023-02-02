using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEst : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    public bool estEnter = false;
    public Transform spawnPosTerrainEst;
    public GameObject spawneeGlobeEst;

    //InputDialogue
    bool inputDialogue;

    public static OnTriggerEst current;
    private void Awake()
    {
        current = this;
    }
    public event Action onTriggerEnterEst;
    public void TriggerEnter()
    {
        if (onTriggerEnterEst != null)
        {
            onTriggerEnterEst();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            current.TriggerEnter();
            /*print("Un Objet est rentré dans la zone est");*/
            /*myMaterial.color = Color.green;*/
            estEnter = true;
            Instantiate(spawneeGlobeEst, spawnPosTerrainEst.position, spawnPosTerrainEst.rotation);
            if (GameObject.Find("SphereNord(Clone)") != null)
                Destroy(GameObject.Find("SphereNord(Clone)"));
            if (GameObject.Find("SphereSud(Clone)") != null)
                Destroy(GameObject.Find("SphereSud(Clone)"));
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

        if (Input.GetKeyDown("[6]") && inputDialogue == false)
        {
            current.TriggerEnter();
        }
    }

    void Start()
    {
        inputDialogue = false;
    }
}
