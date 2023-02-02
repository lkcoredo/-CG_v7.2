using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BanditScript : MonoBehaviour
{
    public GameObject spawneeBandit;
    public Transform spawnPosBandit;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(addBandit());
    }

    IEnumerator addBandit()
    {
        while (true)
        {
            /*GameObject parent = new GameObject("parent");*/
            GameObject enfant = Instantiate(spawneeBandit, spawnPosBandit.position, spawnPosBandit.rotation);
            FindObjectOfType<Livings>().add_hostile();
            /*enfant.transform.SetParent(parent.GetComponent<Transform>());*/
            yield return new WaitForSeconds(10);
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
