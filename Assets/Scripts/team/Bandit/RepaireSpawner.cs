using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepaireSpawner : MonoBehaviour
{
    public GameObject spawneeRepaire;
    public Transform spawnPosRepaire;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(addRepaire());
    }

    IEnumerator addRepaire()
    {
        while (true)
        {
            float random1 = Random.Range(0f, 100f); //generates random angle in radians
            float random2 = Random.Range(0f, 100f);
            Vector3 randomVector = new Vector3(random1 + spawnPosRepaire.position.x, -230, random2 + spawnPosRepaire.position.z);
            /*GameObject parent = new GameObject("parent");*/
            GameObject enfant = Instantiate(spawneeRepaire, randomVector, spawnPosRepaire.rotation);
            /*enfant.transform.SetParent(parent.GetComponent<Transform>());*/
            yield return new WaitForSeconds(100);
            
        }
    }



    void Update()
    {
        if ((player.transform.position - this.transform.position).sqrMagnitude < 3 * 3)
        {
            Destroy(transform.gameObject, 1);
        }
    }
}
