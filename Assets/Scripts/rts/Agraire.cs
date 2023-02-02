using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Agraire : MonoBehaviour
{
    /*[SerializeField]*/
    public string role;
    public GameObject objectif;
    public GameObject arbre;
    public GameObject reserve;
    public GameObject pierre;
    private float distance_objectif;
    private float distance_reserve;
    private UnityEngine.AI.NavMeshAgent agent;
    public Vector3 retrait;
    public float chaseRange = 100;
    public float actionRange = 3;
    public bool stockMade = false;
    public Ressources MesRessources;
    public DialogueSystem script;
    public NPC NPCscript;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        arbre = GameObject.Find("pine1a");
        reserve = GameObject.Find("CanopyStock");
        pierre = GameObject.Find("Prop_Stone_Grouped_C");
        role = "none";
    }

    // Update is called once per frame
    void Update()
    {
        reserve = GameObject.Find("CanopyStock");

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (gameObject.name == NPCscript.currentNPCName || script.MessageEnCours.Contains("tous"))
            {
                print("gameObject.name" + gameObject.name);
                print("NPCscript.currentNPCName" + NPCscript.currentNPCName);

                if (script.MessageEnCours.Contains("bucheron"))
                {
                    role = "bucheron";
                }
                else if (script.MessageEnCours.Contains("carreleur"))
                {
                    role = "carreleur";
                }
                else if (script.MessageEnCours.Contains("fermier"))
                {
                    role = "fermier";
                }
                else if (script.MessageEnCours.Contains("puit"))
                {
                    role = "puit";
                }
                else if (script.MessageEnCours.Contains("mineur"))
                {
                    role = "mineur";
                }
                else if (script.MessageEnCours.Contains("berger"))
                {
                    role = "berger";
                }
                else if (script.MessageEnCours.Contains("chasseur"))
                {
                    role = "chasseur";
                }
                else if (script.MessageEnCours.Contains("pecheur"))
                {
                    role = "pecheur";
                }
                else if (script.MessageEnCours.Contains("moine"))
                {
                    role = "moine";
                }
                else if (script.MessageEnCours.Contains("aubergiste"))
                {
                    role = "aubergiste";
                }
                else if (script.MessageEnCours.Contains("constructeur"))
                {
                    role = "constructeur";
                }
                else if (script.MessageEnCours.Contains("explorateur"))
                {
                    role = "explorateur";
                }
                else if (script.MessageEnCours.Contains("patrouilleur"))
                {
                    role = "patrouilleur";
                }
                else if (script.MessageEnCours.Contains("garnison"))
                {
                    role = "garnison";
                }
                else if (script.MessageEnCours.Contains("soldat"))
                {
                    role = "soldat";
                }
            }
        }

        if (role == "bucheron")
        {
            objectif = GameObject.Find("pine1a");
        }
        else if (role == "carreleur")
        {
            objectif = GameObject.Find("Prop_Stone_Grouped_C");
        }
        else if (role == "fermier")
        {
            objectif = GameObject.Find("Mill");
        }
        else if (role == "puit")
        {
            objectif = GameObject.Find("Well");
        }
        else if (role == "mineur")
        {
            // mine de fer / mine d'or
        }
        else if (role == "berger")
        {
            // mouton
        }
        else if (role == "chasseur")
        {
            // animaux
        }
        else if (role == "pecheur")
        {
            // point d'eau
        }
        else if (role == "moine")
        {
            // eglise // Church1_End_B
            objectif = GameObject.Find("Church1_End_B");
        }
        else if (role == "aubergiste")
        {
            // auberge // Auberge
            objectif = GameObject.Find("Auberge");
        }
        else if (role == "constructeur")
        {
            // chantiers (tableau) // GreenHouse1_End_A
            objectif = GameObject.Find("GreenHouse1_End_A");
        }
        else if (role == "explorateur")
        {
            // aléatoire
        }
        else if (role == "patrouilleur")
        {
            // zone de patrouille (tableau)
        }
        else if (role == "garnison")
        {
            // caserne
        }
        else if (role == "soldat")
        {
            // ennemi (tableau)
        }
        else if (role == "none")
        {
            // doing nothing
        }

        


        if (role == "none")
        {
            this.GetComponent<Animator>().Play("idle");
        } 
        else
        {
            distance_objectif = Vector3.Distance(objectif.transform.position, transform.position);
            distance_reserve = Vector3.Distance(reserve.transform.position, transform.position);

            if (stockMade == false)
            {
                if (distance_objectif > actionRange)
                {
                    this.GetComponent<Animator>().Play("walk");
                    agent.destination = objectif.transform.position;
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
                if (distance_reserve > actionRange)
                {
                    this.GetComponent<Animator>().Play("walk");
                    agent.destination = reserve.transform.position;
                    transform.LookAt(agent.destination, Vector3.up);
                }
                else
                {
                    this.GetComponent<Animator>().Play("idle");
                    StartCoroutine(waiter());
                    stockMade = false;
                    // + 10 de ressources
                    if (role == "bucheron")
                    {
                        Ressources.Instance.currentWood = Ressources.Instance.currentWood + 10;
                    }
                    else if (role == "carreleur")
                    {
                        Ressources.Instance.currentStone = Ressources.Instance.currentStone + 10;
                    }
                    else if (role == "fermier")
                    {
                        Ressources.Instance.currentRation = Ressources.Instance.currentRation + 10;
                    }
                    else if (role == "puit")
                    {
                        // eau
                    }
                    else if (role == "mineur")
                    {
                        Ressources.Instance.currentMetal = Ressources.Instance.currentMetal + 10;
                    }
                    else if (role == "berger")
                    {
                        Ressources.Instance.currentLaine = Ressources.Instance.currentLaine + 10;
                    }
                    else if (role == "chasseur")
                    {
                        Ressources.Instance.currentRation = Ressources.Instance.currentRation + 50;
                    }
                    else if (role == "pecheur")
                    {
                        Ressources.Instance.currentRation = Ressources.Instance.currentRation + 40;
                    }
                    else if (role == "moine")
                    {
                        // Bougie
                    }
                    else if (role == "aubergiste")
                    {
                        // Bière
                    }
                    else if (role == "constructeur")
                    {
                        // Chercher les chantiers que le joueur a mis en place dans un tableau... 
                        // Construire...
                    }
                    else if (role == "explorateur")
                    {
                        // Explorer aléatoirement la map ...
                    }
                    else if (role == "patrouilleur")
                    {
                        // Definir des zones de patrouilles dans un tableau
                        // Patrouiller
                    }
                    else if (role == "garnison")
                    {
                        // Rester en garnison dans un endroit stratégique de défense
                    }
                    else if (role == "soldat")
                    {
                        // attacker l'ennemi au meilleur moment
                    }

                }
            }
        }
    }

    IEnumerator waiter()
    {
        //Wait for 4 seconds
        yield return new WaitForSeconds(20);
    }


}
