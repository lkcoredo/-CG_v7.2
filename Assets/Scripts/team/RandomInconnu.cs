using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class RandomInconnu : MonoBehaviour
{

    private float Distance;
    /*    public Transform TargetPlayer;*/
    /* public Transform TargetTeam2;*/
    private UnityEngine.AI.NavMeshAgent agent;
    public float chaseRange = 20;
    public float attackRange = 10;
    public float attackRepeatTime = 1;
    private float attackTime;
    public float TheDamage;
    private Animation animations;
    public float enemyHealth;
    private bool isDead = false;
    public bool isMoving = false;

    

    //random
    public float timer;
    public int newtarget;
    public float speed;
    public Vector3 TargetRandom;
    public Vector3 NoTarget;
    public GameObject[] TargetTeam2Array;

    public int deathRandom;
    float lockPos = 0;


    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animations = gameObject.GetComponent<Animation>();
        attackTime = Time.time;
        FindObjectOfType<Livings>().add_messager();
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z);*/

        if (!isDead)
        {
            TargetTeam2Array = GameObject.FindGameObjectsWithTag("Player");

            for (int i = 0; i < TargetTeam2Array.Length; i++)
            {
                Distance = Vector3.Distance(TargetTeam2Array[i].transform.position, transform.position);

                if (Distance > chaseRange)
                {
                    if (isMoving == true && !isDead)
                    {
                        this.GetComponent<Animator>().Play("Armature_idle_knight");
                    }
                }

                if (Distance < chaseRange && Distance > attackRange && !isDead)
                {
                    this.GetComponent<Animator>().Play("Armature_walk_knight");
                    agent.destination = TargetTeam2Array[i].transform.position;
                    transform.LookAt(agent.destination, Vector3.up);
                }

                if (Distance < attackRange)
                {
                    this.GetComponent<Animator>().Play("Armature_idle_knight");
                    isMoving = false;
                    agent.destination = transform.position;

                    /*transform.LookAt(agent.destination, Vector3.up); PUTAIN DE COMMANDE QUI FAIS BUGER !!!! */
                }
            }
        } 
        else
        {
            /*NoTarget = transform.position;
            agent.SetDestination(NoTarget);
            agent.destination = NoTarget;*/
        }
    }

    public void ApplyDamage(float TheDamage)
    {
        enemyHealth = enemyHealth - TheDamage;
        print(gameObject.name + " a subit " + TheDamage + " points de dégâts.");

        if (enemyHealth <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        if (isDead == false)
        {
            isDead = true;
            isMoving = false;
            this.GetComponent<Animator>().Play("Armature_death_knight");
            FindObjectOfType<Livings>().remove_dead_messager();
        }


        
        isDead = true;

        
        Destroy(transform.gameObject, 1000);
    }
}


