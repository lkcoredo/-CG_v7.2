using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbre : MonoBehaviour
{
    public float currentHealth;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ApplyDamage(float TheDamage)
    {
        currentHealth = currentHealth - TheDamage;
        print(gameObject.name + " a subit " + TheDamage + " points de dégâts.");

        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (other.tag == "zone")
            {
                Debug.Log("Monster ENTER THE ZONE");
                ApplyDamage(100);
            }
        }

    }

    public void Dead()
    {
        isDead = true;
        Destroy(transform.gameObject, 1);
    }

}
