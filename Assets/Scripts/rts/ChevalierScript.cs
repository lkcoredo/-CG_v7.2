using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChevalierScript : MonoBehaviour
{

    public GameObject spawneeChevalier;
    public Transform spawnPosChevalier;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(addChevalier());
    }

    IEnumerator addChevalier()
    {
        while (true)
        {
            /*GameObject parent = new GameObject("parent");*/
            GameObject enfant = Instantiate(spawneeChevalier, spawnPosChevalier.position, spawnPosChevalier.rotation);
            FindObjectOfType<Livings>().add_neutre();
            /*enfant.transform.SetParent(parent.GetComponent<Transform>());*/
            yield return new WaitForSeconds(50);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
