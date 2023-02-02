using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITeam1 : MonoBehaviour
{
    private float Distance;
    /*    public Transform TargetPlayer;*/
   /* public Transform TargetTeam2;*/
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
    public GameObject[] TargetTeam2Array;




    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animations = gameObject.GetComponent<Animation>();
        attackTime = Time.time;
        FindObjectOfType<Livings>().add_neutre();
    }

    // Update is called once per frame
    void Update()
    {



        if (!isDead)
        {
            /*TargetPlayer = GameObject.Find("Player").transform;
            TargetTeam2 = GameObject.Find("Zombie1").transform;*/
            TargetTeam2Array = GameObject.FindGameObjectsWithTag("team2");

            for (int i = 0; i < TargetTeam2Array.Length; i++)
            {
                Distance = Vector3.Distance(TargetTeam2Array[i].transform.position, transform.position);

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
                        /*patroling();*/
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

                if (Distance < chaseRange && Distance > attackRange && TargetTeam2Array[i].GetComponent<AITeam2>().enemyHealth > 0)
                {
                    animations.Play("walk");
                    agent.destination = TargetTeam2Array[i].transform.position;
                }

                if (Distance < attackRange && TargetTeam2Array[i].GetComponent<AITeam2>().enemyHealth > 0)
                {
                    isMoving = false;
                    agent.destination = transform.position;

                    if (Time.time > attackTime)
                    {
                        animations.Play("idle");
                        TargetTeam2Array[i].GetComponent<AITeam2>().ApplyDamage(TheDamage);
                        Debug.Log("L'ennemi a envoy� " + TheDamage + " points de d�g�ts");
                        attackTime = Time.time + attackRepeatTime;
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
