using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class AITeam2 : MonoBehaviour
{
    private float Distance;
    /*public Transform TargetPlayer;*/
    /*public Transform TargetTeam1;*/
    private UnityEngine.AI.NavMeshAgent agent;
    public float chaseRange = 10;
    public float attackRange = 2.2f;
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

    public GameObject[] tag_1;
    public GameObject[] tag_2;
    public GameObject[] final_array;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animations = gameObject.GetComponent<Animation>();
        attackTime = Time.time;
        FindObjectOfType<Livings>().add_hostile();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {

            /* TargetPlayer = GameObject.Find("Player").transform;*/
            /*TargetTeam1 = GameObject.Find("palad2").transform;*/
            /*final_array = GameObject.FindGameObjectsWithTag("team1");*/
            tag_1 = GameObject.FindGameObjectsWithTag("team1");
            tag_2 = GameObject.FindGameObjectsWithTag("neutre");
            final_array = tag_1.Concat(tag_2).ToArray();




            for (int i = 0; i < final_array.Length; i++) 
            {
                Distance = Vector3.Distance(final_array[i].transform.position, transform.position);

                if (Distance > chaseRange)
                {
                    if (isMoving == true)
                    {
                        animations.Play("walk");
                    }
                    if (isMoving == false && Distance < attackRange)
                    {
                        animations.Play("idle");
                    }


                    timer += Time.deltaTime;
                    if (timer >= newtarget && timer < (1.1 * newtarget))
                    {
                        /* patroling();*/
                        animations.Play("idle");
                    }

                    if (timer >= (3 * newtarget) && timer < (4 * newtarget))
                    {
                        TargetRandom = agent.transform.position;
                        agent.SetDestination(TargetRandom);
                        isMoving = false;
                    }

                    if (timer >= (4 * newtarget))
                    {
                        timer = 0;
                    }
                }

                //Team1
                if (final_array[i].GetComponent<AITeam1>() != null)
                {
                    if (Distance < chaseRange && Distance > attackRange && final_array[i].GetComponent<AITeam1>().enemyHealth > 0)
                    {
                        animations.Play("walk");
                        agent.destination = final_array[i].transform.position;
                    }

                    if (Distance < attackRange && final_array[i].GetComponent<AITeam1>().enemyHealth > 0)
                    {
                        isMoving = false;
                        agent.destination = transform.position;

                        if (Time.time > attackTime)
                        {
                            animations.Play("idle");
                            final_array[i].GetComponent<AITeam1>().ApplyDamage(TheDamage);
                            Debug.Log("L'ennemi a envoy� " + TheDamage + " points de d�g�ts");
                            attackTime = Time.time + attackRepeatTime;
                        }
                    }
                }

                //Roturier
                if (final_array[i].GetComponent<Roturier>() != null)
                {
                    if (Distance < chaseRange && Distance > attackRange && final_array[i].GetComponent<Roturier>().enemyHealth > 0)
                    {
                        animations.Play("walk");
                        agent.destination = final_array[i].transform.position;
                    }

                    if (Distance < attackRange && final_array[i].GetComponent<Roturier>().enemyHealth > 0)
                    {
                        isMoving = false;
                        agent.destination = transform.position;

                        if (Time.time > attackTime)
                        {
                            animations.Play("Attack1");
                            final_array[i].GetComponent<Roturier>().ApplyDamage(TheDamage);
                            Debug.Log("L'ennemi a envoy� " + TheDamage + " points de d�g�ts");
                            attackTime = Time.time + attackRepeatTime;
                        }
                    }
                }


            }
        }
    }


    void patroling()
    {
        isMoving = true;
        float myX = gameObject.transform.position.x;
        float myZ = gameObject.transform.position.z;

        float xPos = myX + Random.Range(myX - 100, myX + 100);
        float zPos = myZ + Random.Range(myZ - 100, myZ + 100);

        TargetRandom = new Vector3(xPos, gameObject.transform.position.y, zPos);
        agent.SetDestination(TargetRandom);
    }

    public void ApplyDamage(float TheDamage)
    {
        enemyHealth = enemyHealth - TheDamage;
        print(gameObject.name + " a subit " + TheDamage + " points de d�g�ts.");

        if (enemyHealth <= 0)
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
        animations.Play("dead");
        Destroy(transform.gameObject, 1000);
    }

    /*    private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, sightRange);
        }*/
}
