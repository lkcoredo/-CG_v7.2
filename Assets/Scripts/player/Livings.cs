using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Livings : MonoBehaviour
{

    [SerializeField]
    private Text _title_hostile;
    [SerializeField]
    private Text _title_neutre;
    [SerializeField]
    private Text _title_messager;
    [SerializeField]
    private Text _title_equipe;
    [SerializeField]
    private Text _title_quete;
    int i_oh = 0;
    int i_op = 0;
    int i_ot1 = 0;
    int i_ot2 = 0;
    int i_on = 0;
    int i_om = 0;
    int i_oe = 0;
    string contenu_quete = "aucune quete en cours...";

    public List<string> list_nom = new List<string>();

    /*String[] str = list.ToArray();*/

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] objects_hostile = GameObject.FindGameObjectsWithTag("hostile");
        GameObject[] objects_neutre = GameObject.FindGameObjectsWithTag("neutre");
        GameObject[] objects_messager = GameObject.FindGameObjectsWithTag("messager");
        GameObject[] objects_equipe = GameObject.FindGameObjectsWithTag("equipe");
        /*GameObject[] objects_procedural = GameObject.FindGameObjectsWithTag("procedural");
        GameObject[] objects_team1 = GameObject.FindGameObjectsWithTag("team1");
        GameObject[] objects_team2 = GameObject.FindGameObjectsWithTag("team2");
        */

        /*foreach (GameObject element in objects_hostile)
        {
            if (!list_existing_names.Contains(element.name))
            {
                list_existing_names.Add(element.name);
                i_oh++;
            }
        }
        foreach (GameObject element in objects_neutre)
        {
            if (!list_existing_names.Contains(element.name))
            {
                list_existing_names.Add(element.name);
                i_on++;
            }

        }
        foreach (GameObject element in objects_messager)
        {
            if (!list_existing_names.Contains(element.name))
            {
                list_existing_names.Add(element.name);
                i_om++;
            }
        }
        foreach (GameObject element in objects_equipe)
        {
            if (!list_existing_names.Contains(element.name))
            {
                list_existing_names.Add(element.name);
                i_oe++;
            }
        }*/
        /*foreach (GameObject element in objects_procedural)
        {
            i_op++;
        }
        foreach (GameObject element in objects_team1)
        {
            i_ot1++;
        }
        foreach (GameObject element in objects_team2)
        {
            i_ot2++;
        }
        
        
        */
        int total = i_oh + i_ot1 + i_ot2 + i_on + i_om + i_oe;
        /*print("Il y a (" + total + ") êtres vivants dont : ");
        print("Il y a (" + i_oh + ") enemie(s)");
        print("Il y a (" + i_on + ") neutre(s)");
        print("Il y a (" + i_om + ") messager(s)");
        print("Il y a (" + i_oe + ") allié(s)");*/
        /*print("Il y a (" + i_ot1 + ") membre(s) de la team1");
        print("Il y a (" + i_ot2 + ") membre(s) de la team2");
        */

        /*print("Il y a (" + i_op + ") objets procedural");*/

        _title_hostile.text = "- Enemie(s) (" + i_oh + ")";
        _title_neutre.text = "- Neutre(s) (" + i_on + ")";
        _title_messager.text = "- Messager(s) (" + i_om + ")";
        _title_equipe.text = "- Allié(s) (" + i_oe + ")";
        _title_quete.text = contenu_quete;
    }

    public void remove_dead_hostile()
    {
        i_oh = i_oh - 1;
    }

    public void remove_dead_messager()
    {
        i_om = i_om - 1;
    }

    public void remove_dead_villageois()
    {
        i_oe = i_oe - 1;
    }

    public void remove_dead_neutre()
    {
        i_on = i_on - 1;
    }

    public void add_hostile()
    {
        i_oh = i_oh + 1;
    }

    public void add_messager()
    {
        i_om = i_om + 1;
    }

    public void add_villageois()
    {
        i_oe = i_oe + 1;
    }

    public void add_neutre()
    {
        i_on = i_on + 1;
    }


    public void add_quete(string contenu)
    {
        contenu_quete = contenu;
        _title_quete.text = contenu;
       /* print("contenu : " + contenu);*/
    }

    public void add_personnage_nom(string nom)
    {
        list_nom.Add(nom);
        string[] str = list_nom.ToArray();
    }

    //FindObjectOfType<Livings>().remove_all(); => to call the function in another script
    public void remove_all()
    {
        i_oh = 0;
        i_op = 0;
        i_ot1 = 0;
        i_ot2 = 0;
        i_on = 0;
        i_om = 0;
        i_oe = 0;
    }
}
