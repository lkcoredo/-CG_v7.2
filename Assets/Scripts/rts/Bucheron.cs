using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucheron : MonoBehaviour
{

    public GameObject arbre;
    public GameObject canopy;
    private float distance_arbre;
    private float distance_canopy;
    private UnityEngine.AI.NavMeshAgent agent;
    public Vector3 retrait;
    public float chaseRange = 100;
    public float actionRange = 3;
    public bool stockMade = false;
    public Ressources MesRessources;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        arbre = GameObject.Find("pine1a");
        canopy = GameObject.Find("CanopyStock");

    }

    // Update is called once per frame
    void Update()
    {
        
        arbre = GameObject.Find("pine1a");
        canopy = GameObject.Find("CanopyStock");
        distance_arbre = Vector3.Distance(arbre.transform.position, transform.position);
        distance_canopy = Vector3.Distance(canopy.transform.position, transform.position);

        if (stockMade == false)
        {
            if (distance_arbre > actionRange)
            {
                this.GetComponent<Animator>().Play("walk");
                agent.destination = arbre.transform.position;
                transform.LookAt(agent.destination, Vector3.up);
            }
            else
            {
                this.GetComponent<Animator>().Play("idle");
                StartCoroutine(waiter());
                stockMade = true;
            }
        } 
        else
        {
            if (distance_canopy > actionRange)
            {
                this.GetComponent<Animator>().Play("walk");
                agent.destination = canopy.transform.position;
                transform.LookAt(agent.destination, Vector3.up);
            }
            else
            {
                this.GetComponent<Animator>().Play("idle");
                StartCoroutine(waiter());
                stockMade = false;
                // + 10 de bois
                Ressources.Instance.currentWood = Ressources.Instance.currentWood + 10;
            }
        }



    }

    IEnumerator waiter()
    {
        //Wait for 4 seconds
        yield return new WaitForSeconds(20);
    }
}
