using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrisBois : MonoBehaviour
{
    // Ressources
    public Ressources MesRessources;

    // Start is called before the first frame update
    void Start()
    {
        /*Debug.Log(Ressources.Instance.currentWood);*/
        /*Ressources.Instance.currentWood = Ressources.Instance.currentWood + 7;
        StartCoroutine(addWood());*/
    }

    IEnumerator addWood()
    {
        while (true)
        {
            Ressources.Instance.currentWood = Ressources.Instance.currentWood + 5;
            yield return new WaitForSeconds(10);
        }
    }
}
