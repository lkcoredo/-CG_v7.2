using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerSud : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    public bool sudEnter = false;
    public Transform spawnPosTerrainSud;
    public GameObject spawneeGlobeSud;

    //InputDialogue
    bool inputDialogue;

    public static OnTriggerSud current;
    private void Awake()
    {
        current = this;
    }
    public event Action onTriggerEnterSud;
    public void TriggerEnter()
    {
        if (onTriggerEnterSud != null)
        {
            onTriggerEnterSud();
        }
    }



    public void OnTriggerEnter(Collider col)
    {
        if(col.name == "Player")
        {
            current.TriggerEnter();
            /*print("Un Objet est rentré dans la zone sud");*/
            sudEnter = true;
            GameObject globeSud = Instantiate(spawneeGlobeSud, spawnPosTerrainSud.position, spawnPosTerrainSud.rotation);
            if (GameObject.Find("SphereNord(Clone)") != null)
                Destroy(GameObject.Find("SphereNord(Clone)"));
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

        if (Input.GetKeyDown("[2]") && inputDialogue == false)
        {
            current.TriggerEnter();
        }
    }


    void Start()
    {
        inputDialogue = false;
    }
}
