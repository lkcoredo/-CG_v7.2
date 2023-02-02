using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;


public class HostileToPlayer : MonoBehaviour
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
    private Rigidbody rb;

    

    //random
    public float timer;
    public int newtarget;
    public float speed;
    public Vector3 TargetRandom;
    public Vector3 NoTarget;
    public GameObject[] tag_1;
    public GameObject[] tag_2;
    public GameObject[] final_array;

    public int deathRandom;

    //deathragdoll
    /*[Header("References")]
    [SerializeField] private Animator animator = null;*/

    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;


    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animations = gameObject.GetComponent<Animation>();
        attackTime = Time.time;
        rb = GetComponent<Rigidbody>();
        FindObjectOfType<Livings>().add_hostile();
        /*  ragdollBodies = GetComponentsInChildren<Rigidbody>();
          ragdollColliders = GetComponentsInChildren<Collider>();

          ToggleRagdoll(false);*/

        /*Invoke(nameof(Dead), 5f);*/
    }

    // Update is called once per frame
    void Update()
    {

        if (!isDead)
        {
            /*TargetPlayer = GameObject.Find("Player").transform;*/
            /*TargetTeam2 = GameObject.Find("Zombie1").transform;*/
            /*TargetTeam2Array = GameObject.FindGameObjectsWithTag("team2 | Player");*/
            tag_1 = GameObject.FindGameObjectsWithTag("Player") ;
            tag_2 = GameObject.FindGameObjectsWithTag("neutre");
            final_array = tag_1.Concat(tag_2).ToArray();

            //|| GameObject.FindGameObjectsWithTag("neutre")
            for (int i = 0; i < final_array.Length; i++)
            {
                Distance = Vector3.Distance(final_array[i].transform.position, transform.position);

                if (Distance > chaseRange)
                {
                    if (isMoving == true && !isDead)
                    {
                        animations.Play("Walk");
                    }
                    if (isMoving == false && Distance < attackRange)
                    {
                        animations.Play("Idle");
                    }


                    timer += Time.deltaTime;
                    if (timer >= newtarget && timer < (1.1 * newtarget))
                    {
                        /*patroling();*/
                        animations.Play("Idle");
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

                if (final_array[i].GetComponent<PlayerInventory>() != null)
                {
                    if (Distance < chaseRange && Distance > attackRange && final_array[i].GetComponent<PlayerInventory>().currentHealth > 0 && !isDead)
                    {
                        animations.Play("Walk");
                        agent.destination = final_array[i].transform.position;
                        transform.LookAt(agent.destination, Vector3.up);
                    }

                    if (Distance < attackRange && final_array[i].GetComponent<PlayerInventory>().currentHealth > 0)
                    {
                        isMoving = false;
                        agent.destination = transform.position;

                        if (Time.time > attackTime)
                        {
                            transform.LookAt(agent.destination, Vector3.up);

                            attack_animation();

                            final_array[i].GetComponent<PlayerInventory>().ApplyDamage(TheDamage);
                            Debug.Log("L'ennemi a envoy� " + TheDamage + " points de d�g�ts");
                            attackTime = Time.time + attackRepeatTime;
                        }
                    }
                }

                if (final_array[i].GetComponent<Roturier>() != null)
                {
                    if (Distance < chaseRange && Distance > attackRange && final_array[i].GetComponent<Roturier>().enemyHealth > 0 && !isDead)
                    {
                        animations.Play("Walk");
                        agent.destination = final_array[i].transform.position;
                        transform.LookAt(agent.destination, Vector3.up);
                    }

                    if (Distance < attackRange && final_array[i].GetComponent<Roturier>().enemyHealth > 0)
                    {
                        isMoving = false;
                        agent.destination = transform.position;

                        if (Time.time > attackTime)
                        {
                            transform.LookAt(agent.destination, Vector3.up);

                            attack_animation();

                            final_array[i].GetComponent<Roturier>().ApplyDamage(TheDamage);
                            Debug.Log("L'ennemi a envoy� " + TheDamage + " points de d�g�ts");
                            attackTime = Time.time + attackRepeatTime;
                        }
                    }
                }

                
            }
        } 
        else
        {
            NoTarget = transform.position;
            agent.SetDestination(NoTarget);
            agent.destination = NoTarget;
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
        if (isDead == false)
        {
            isDead = true;
            isMoving = false;
            /*ToggleRagdoll(true);

            foreach (Rigidbody rb in ragdollBodies)
            {
                rb.AddExplosionForce(107f, new Vector3(-1f, 0.5f, -1f), 5f, 0f, ForceMode.Impulse);
            }*/

            rb.velocity = Vector3.zero;
            /*this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            this.gameObject.GetComponent<Rigidbody>().detectCollisions = false;*/

            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            deathRandom = Random.Range(0, 10);
            if (deathRandom == 0)
                animations.Play("Death");
            if (deathRandom == 1)
                animations.Play("Death1");
            if (deathRandom == 2)
                animations.Play("Death2");
            if (deathRandom == 3)
                animations.Play("Death3");
            if (deathRandom == 4)
                animations.Play("Death4");
            if (deathRandom == 5)
                animations.Play("Death5");
            if (deathRandom == 6)
                animations.Play("Death6");
            if (deathRandom == 7)
                animations.Play("Death7");
            if (deathRandom == 8)
                animations.Play("Death8");
            if (deathRandom == 9)
                animations.Play("Death9");
            if (deathRandom == 10)
                animations.Play("Death10");

            FindObjectOfType<Livings>().remove_dead_hostile();
        }


        
        isDead = true;

        
        Destroy(transform.gameObject, 1000);
    }

    private void attack_animation()
    {
        deathRandom = Random.Range(1, 27);
        if (deathRandom == 1)
            animations.Play("Attack1");
        if (deathRandom == 2)
            animations.Play("Attack2");
        if (deathRandom == 3)
            animations.Play("Attack3");
        if (deathRandom == 4)
            animations.Play("Attack4");
        if (deathRandom == 5)
            animations.Play("Attack5");
        if (deathRandom == 6)
            animations.Play("Attack6");
        if (deathRandom == 7)
            animations.Play("Attack7");
        if (deathRandom == 8)
            animations.Play("Attack8");
        if (deathRandom == 9)
            animations.Play("Attack9");
        if (deathRandom == 10)
            animations.Play("Attack10");
        if (deathRandom == 11)
            animations.Play("Attack11");
        if (deathRandom == 12)
            animations.Play("Attack12");
        if (deathRandom == 13)
            animations.Play("Attack13");
        if (deathRandom == 14)
            animations.Play("Attack14");
        if (deathRandom == 15)
            animations.Play("Attack15");
        if (deathRandom == 16)
            animations.Play("Attack16");
        if (deathRandom == 17)
            animations.Play("Foot1");
        if (deathRandom == 18)
            animations.Play("Foot2");
        if (deathRandom == 19)
            animations.Play("Foot3");
        if (deathRandom == 20)
            animations.Play("Foot4");
        if (deathRandom == 21)
            animations.Play("Foot5");
        if (deathRandom == 22)
            animations.Play("Foot6");
        if (deathRandom == 23)
            animations.Play("Foot7");
        if (deathRandom == 24)
            animations.Play("Foot8");
        if (deathRandom == 25)
            animations.Play("Foot9");
        if (deathRandom == 26)
            animations.Play("Foot10");
        if (deathRandom == 27)
            animations.Play("Foot11");
    }

    /*    private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, sightRange);
        }*/

/*    private void ToggleRagdoll(bool state)
    {
        *//*animator.enabled = !state;*//*

        foreach (Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = !state;
        }

        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = state;
        }
    }*/
}


