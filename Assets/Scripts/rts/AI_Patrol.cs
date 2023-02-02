using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Patrol : MonoBehaviour
{

    //ai sight
    public bool playerIsInLOS = false;
    public float fieldOfViewAngle = 160f;
    public float losRadius = 45f;

    //ai sight and memory
    private bool aiMemorizesPlayer = false;
    public float memoryStartTime = 10f;
    private float increasingMemoryTime;

    //ai hearing
    Vector3 noisePosition;
    private bool aiHeardPlayer = false;
    public float noiseTravelDistance = 50f;
    public float spinSpeed = 3f;
    private bool canSpin = false;
    private float isSpinningTime; //search at player-noise-position
    public float spinTime = 3f;


    //patroling randomly between waypoints
    public Transform[] moveSpots;
    private int randomSpot;

    private float waitTime;
    public float startWaitTime = 1f;

    NavMeshAgent nav;

    //AI Strafe
    public float distToPlayer = 5.0f; // straferadius

    private float randomStrafeStartTime;
    private float waitStrafeTime;
    public float t_minStrafe; // min and max time ai waits once it has reached the "strafe"
    public float t_maxStrafe;

    public Transform strafeRight;
    public Transform strafeLeft;
    private int randomStrafeDir;

    public float chaseRadius = 20f;
    public float facePlayerFactor = 20f;

    // Start is called before the first frame update
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;
    }

    // Update is called once per frame
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        randomStrafeDir = Random.Range(0, 2);
    }

    void Update()
    {
        //float distance = Vector3.Distance(CharacterMotor.playerPos, transform.position);
        /*if (Time.framecount % frameInterval == 0)  // set framinInterval to 3, 5 or 10 and test your AI
        {
            float distance = ((CharacterMotor.playerPos - transform.position).sqr.Magnitude); // faster than Vector3.Distance
            if ((distance* distance) * smaller * losRadius) {
                playerIsInLineOfSight = true;
            }
        }*/

        /*if (playerIsInLineOfSight == true)
        {
           
        }*/

        float distance = Vector3.Distance(CharacterMotor.playerPos, transform.position);
        
        if (distance <= losRadius)
        {
            CheckLOS();
        }

        if (nav.isActiveAndEnabled)
        {
            if(playerIsInLOS == false && aiMemorizesPlayer == false && aiHeardPlayer == false)
            {
                Patrol();
                NoiseCheck();
                StopCoroutine(AiMemory());
            }
            else if (aiHeardPlayer == true && playerIsInLOS == false && aiMemorizesPlayer == false)
            {
                canSpin = true;
                GoToNoisePosition();
            }
            else if (playerIsInLOS == true)
            {
                aiMemorizesPlayer = true;
                FacePlayer();
                ChasePlayer();
            }
            else if (aiMemorizesPlayer == true && playerIsInLOS == false)
            {
                ChasePlayer();
                StartCoroutine(AiMemory());
            }
        }


        /*if (distance > chaseRadius)
        {
            Patrol();
        }
        else if (distance <= chaseRadius)
        {
            ChasePlayer();

            FacePlayer();
        }*/
        // then you replace all the distance checks with the bools like this:

    }

    void NoiseCheck()
    {
        /*print("NoiseChecking...");*/
        float distance = Vector3.Distance(CharacterMotor.playerPos, transform.position);
        if (distance <= noiseTravelDistance)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                noisePosition = CharacterMotor.playerPos;
                aiHeardPlayer = true;
            }
            else
            {
                aiHeardPlayer = false;
                canSpin = false;
            }
        }
    }

    // NEW

    void GoToNoisePosition()
    {
        /*print("GoToNoisePositioning...");*/
        nav.SetDestination(noisePosition);
        if (Vector3.Distance(transform.position, noisePosition) <= 5f && canSpin == true)
        {
            isSpinningTime += Time.deltaTime;
            transform.Rotate(Vector3.up * spinSpeed, Space.World);
            if (isSpinningTime >= spinTime)
            {
                canSpin = false;
                aiHeardPlayer = false;
                isSpinningTime = 0f;
            }
        }
    }

    IEnumerator AiMemory()
    {
        /*zprint("AiMemoring...");*/
        increasingMemoryTime = 0;
        while (increasingMemoryTime < memoryStartTime)
        {
            increasingMemoryTime += Time.deltaTime;
            aiMemorizesPlayer = true;
            yield return null;
        }

        aiHeardPlayer = false;
        aiMemorizesPlayer = false;
    }

    void CheckLOS()
    {
        /*print("CheckLOSing...");*/
        Vector3 direction = CharacterMotor.playerPos - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        if (angle < fieldOfViewAngle * 0.5f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction.normalized, out hit, losRadius))
            {
                if(hit.collider.tag == "Player")
                {
                    playerIsInLOS = true;
                    aiMemorizesPlayer = true;
                } 
                else
                {
                    playerIsInLOS = false;
                }
            }
        }
    }

    void Patrol()
    {
        /*print("Patroling...");*/
        /*print(Vector3.Distance(transform.position, moveSpots[randomSpot].position));*/
        nav.SetDestination(moveSpots[randomSpot].position);

        if(Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 2.0f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            } else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void ChasePlayer()
    {
        /*print("ChasingPlayer...");*/
        this.GetComponent<Animator>().Play("idle");
        float distance = Vector3.Distance(CharacterMotor.playerPos, transform.position);

        if (distance <= chaseRadius && distance > distToPlayer)
        {
            nav.SetDestination(CharacterMotor.playerPos);
        }

        else if (nav.isActiveAndEnabled && distance <= distToPlayer) 
        {
            randomStrafeDir = Random.Range(0, 2);
            randomStrafeStartTime = Random.Range(t_minStrafe, t_maxStrafe);

            if(waitStrafeTime <= 0)
            {
                if(randomStrafeDir == 0)
                {
                    nav.SetDestination(strafeLeft.position);
                } else
                if (randomStrafeDir == 1)
                {
                    nav.SetDestination(strafeRight.position);
                }
                waitStrafeTime = randomStrafeStartTime;
            }
            else
            {
                waitStrafeTime -= Time.deltaTime;
            }
        }
    }

    void FacePlayer()
    {
        /*print("FacingPlayer...");*/
        Vector3 direction = (CharacterMotor.playerPos - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * facePlayerFactor);
    }
}
