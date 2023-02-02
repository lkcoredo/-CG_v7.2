using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class CharacterMotor : MonoBehaviour
{
    PlayerInventory playerInv;

    // Animations du perso
    Animation animations;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Equipment equipmentSystem;

    public static Vector3 playerPos;

    // Vitesse de déplacement
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;

    // Variables concernant l'attaque
    public float attackCooldown;
    private bool isAttacking;
    private bool isSitting;
    private bool isRolling;
    private float currentCooldown;
    public float attackRange;
    public GameObject rayHit;

    // Inputs
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;
    public string inputBackFlip;
    public InputField discussionInputField;

    public PlayerInventory script;

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;

    public int deathRandom;

    // Le personnage est-il mort ?
    public bool isDead = false;

    // Le personnage est-il dans un magasin ?
    public bool isInShop = false;

    //InputDialogue
    bool inputDialogue;

    //Camera
    public GameObject cam1;
    public GameObject cam2;

    public CheckWeapons a;

    [HideInInspector]
    public ItemData itemCurrentlyEquiped;

    public float damageGun = 100f;
    public float rangeGun = 100f;
    public Camera fpsCam;

    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam1.SetActive(false);
        cam2.SetActive(true);
        cam1.SetActive(true);
        cam2.SetActive(false);
        
        inputDialogue = false;
        animations = gameObject.GetComponent<Animation>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
        playerInv = gameObject.GetComponent<PlayerInventory>();
        rayHit = GameObject.Find("RayHit");
        animator = GetComponent<Animator>();

        walkSpeed = script.currentEndurance * walkSpeed;
        runSpeed = script.currentEndurance * runSpeed;
        jumpSpeed = script.currentAgilite * jumpSpeed;
        attackRange = script.currentSouplesse * attackRange;
        attackCooldown = script.currentAgilite * attackCooldown;

        discussionInputField = GameObject.Find("InputField").GetComponent<InputField>();

        //TrackPlayer();
    }

    public async void TrackPlayer()
    {
        while (true)
        {
            playerPos = gameObject.transform.position;
            
            //yield return null;
        }
    }

    bool IsGrounded()
    {
        Vector3 dwn = transform.TransformDirection(Vector3.down);

        return (Physics.Raycast(transform.position, dwn, 1));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && inputDialogue == false)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.P) && inputDialogue == false)
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            discussionInputField.ActivateInputField();
        }

        

        if (!isDead)
        {
            if (Input.GetKeyDown(KeyCode.F) && inputDialogue == false)
            {
                inputDialogue = true;
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                inputDialogue = false;
            }

            

            // si on avance
            if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift) && inputDialogue == false)
            {
                isSitting = false;
                transform.Translate(0, 0, walkSpeed * Time.deltaTime);

                if (!isAttacking && !isRolling)
                {
                    animations.Play("Idle@Walking");
                    /*animator.SetBool("isWalking", true);*/
                }

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Attack();
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    Rolling();
                    script.currentEnergie -= 1;
                }

                if (Input.GetKeyDown(KeyCode.T))
                {
                    FrontFlip();
                    script.currentEnergie -= 1;
                }

            }

            // Si on sprint
            if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift) && inputDialogue == false)
            {
                transform.Translate(0, 0, runSpeed * Time.deltaTime);
                script.currentEnergie -= 0.01;
                script.currentSoif -= 0.01;

                if (!isRolling)
                {
                    animations.Play("Idle@Standard Run");
                }
                

                if (Input.GetKeyDown(KeyCode.R))
                {
                    SprintRolling();
                    script.currentEnergie -= 1;
                }

                if (Input.GetKeyDown(KeyCode.T))
                {
                    JumpRolling();
                    script.currentEnergie -= 1;
                }
            }

            // si on recule
            if (Input.GetKey(inputBack) && inputDialogue == false && !isRolling)
            {
                isSitting = false;
                transform.Translate(0, 0, -(walkSpeed) * Time.deltaTime);

                if (!isAttacking)
                {
                    animations.Play("Idle@Running Backward");
                }

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Attack();
                }

                if (Input.GetKeyDown(KeyCode.X))
                {
                    BackFlip();
                }
            }

            // rotation �  gauche
            if (Input.GetKey(inputLeft) && inputDialogue == false && !isSitting)
            {
                transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
            }

            // rotation �  droite
            if (Input.GetKey(inputRight) && inputDialogue == false && !isSitting)
            {
                transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
            }

            // Si on avance pas et que on recule pas non plus et qu'on ne fait pas de roulade
            if (!Input.GetKey(inputFront) && !Input.GetKey(inputBack) && inputDialogue == false && !Input.GetKeyDown(KeyCode.R) && !isRolling)
            {
                if (!isAttacking && !isSitting)
                {
                    animations.Play("Idle@Breathing Idle");
                }

                if (!IsGrounded())
                {
                    animations.Play("Idle@Jumping Down");
                }

                if (Input.GetKeyDown(KeyCode.Mouse0) && !isSitting && inputDialogue == false)
                {
                    Attack();
                }

                if (Input.GetKeyDown(KeyCode.N))
                {
                    Sit();
                }


            }

            

            

            // Si on saute
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && inputDialogue == false)
            {
                animations.Play("Idle@Jumping Down");
                // Préparation du saut (Nécessaire en C#)
                Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
                v.y = jumpSpeed.y;

                // Saut
                gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
                script.currentEnergie -= 1;
            }

            // Si on backflip
            /*            if (Input.GetKey(inputBackFlip) && inputDialogue == false)
                        {
                            animations.Play("Idle@Backflip");
                        }*/
        }

        if (isAttacking)
        {
            currentCooldown -= Time.deltaTime;
        }

        if (currentCooldown <= 0)
        {
            currentCooldown = attackCooldown;
            isAttacking = false;
        }

        if (isSitting)
        {
            script.currentEnergie += 0.01;
        }

        /*if (isSleeping)
        {
            script.currentEnergie += 1;
        }*/

    }

    //roulade
    public async void Rolling()
    {
        isRolling = true;
        animations.Play("StandToRoll");
        await Task.Delay(2000);
        //yield return new WaitForSeconds(2);
        isRolling = false;
    }

    public async void SprintRolling()
    {
        isRolling = true;
        animations.Play("RollSprint");
        await Task.Delay(1000);
        //yield return new WaitForSeconds(1);
        isRolling = false;
    }

    public async void JumpRolling()
    {
        isRolling = true;
        animations.Play("JumpingStyle");
        await Task.Delay(2000);
        //yield return new WaitForSeconds(2);
        transform.Translate(0, 0, 10);
        isRolling = false;
    }

    public async void FrontFlip()
    {
        isRolling = true;
        animations.Play("FrontFlip");
        await Task.Delay(1500);
        //yield return new WaitForSeconds(1.5f);
        transform.Translate(0, 0, 10);
        isRolling = false;
    }

    public async void BackFlip()
    {
        isRolling = true;
        animations.Play("Backflip");
        await Task.Delay(2000);
        //yield return new WaitForSeconds(1.5f);
        /*transform.Translate(0, 0, 10);*/
        isRolling = false;
    }

    // Sitting
    public void Sit()
    {
        animations.Play("Sitting");

        
        isSitting = true;
    }

    // Fonction d'attaque
    public void Attack()
    {
        if (!isAttacking && inputDialogue == false)
        {
            /*animations.Play("Attack1");*/
            /*animator.SetBool("isBoxing", false);*/
            /*animations.Play("Idle@Boxing");*/


            /*  PlayerScript playerScript = thePlayer.GetComponent<PlayerScript>();
            playerScript.Health -= 10.0f;*/

            

            if(equipmentSystem.equipedWeaponItem != null)
            {
                if(equipmentSystem.equipedBowItem != null)
                {
                    animations.Play("shoot");
                    Shoot();
                }
                else if(equipmentSystem.equipedShootItem != null)
                {
                    animations.Play("shoot");
                    Shoot();
                }
                else if(equipmentSystem.equipedSmashItem != null)
                {
                    animations.Play("sword");
                    Hit();
                }
                else if(equipmentSystem.equipedStabItem != null)
                {
                    animations.Play("sword");
                    Hit();
                }
                else if(equipmentSystem.equipedLaunchItem != null)
                {
                    AttackBarehanded();
                    Hit();
                }
                else if(equipmentSystem.equipedNoneItem != null)
                {
                    AttackBarehanded();
                    Hit();
                } else {
                    AttackBarehanded();
                    Hit();
                }
                //animator.SetTrigger("Attack");
                
            }
            else
            {
                AttackBarehanded();
            }

            //RETABLIR
            /*
            a = FindObjectOfType<CheckWeapons>();

            if (a != null)
            {
                if (a.ArmeDeTir == true)
                {
                    print("Vous tirez avec une arme de tir");
                    //animations.Play("shoot");
                }

                if (a.ArmeDeCombat == true)
                {
                    print("Vous attaquez avec une arme au corps � corps");
                    //animations.Play("sword");
                }

                if (a.ArmeDeTir == false && a.ArmeDeCombat == false)
                {
                    //RETABLIR
                    //AttackBarehanded();
                }
            }
            else
            {
                //AttackBarehanded();
            }
            */

            isAttacking = true;
        }

    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, rangeGun))
        {
            Debug.Log(hit.transform.name);
            Damage(hit);
        }
    }

    public void Hit()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayHit.transform.position, transform.TransformDirection(Vector3.forward), out hit, attackRange))
        {
            Debug.DrawLine(rayHit.transform.position, hit.point, Color.red);
            // | hit.transform.tag == "team2"
            Damage(hit);
        }     
    }

    public void Damage(RaycastHit hit)
    {
                if (hit.transform.tag == "team1")
                {
                    hit.transform.GetComponent<AITeam1>().ApplyDamage(playerInv.currentDamage);
                }

                if (hit.transform.tag == "team2")
                {
                    hit.transform.GetComponent<AITeam2>().ApplyDamage(playerInv.currentDamage);
                }

                if (hit.transform.tag == "hostile")
                {
                    hit.transform.GetComponent<HostileToPlayer>().ApplyDamage(playerInv.currentDamage);
                }

                if (hit.transform.tag == "messager")
                {
                    hit.transform.GetComponent<RandomInconnu>().ApplyDamage(playerInv.currentDamage);
                }

                if (hit.transform.tag == "equipe")
                {
                    hit.transform.GetComponent<villageois>().ApplyDamage(playerInv.currentDamage);
                }

                if (hit.transform.tag == "neutre")
                {
                    hit.transform.GetComponent<Roturier>().ApplyDamage(playerInv.currentDamage);
                }

                if (hit.transform.tag == "wolf")
                {
                    hit.transform.GetComponent<Wolf>().ApplyDamage(playerInv.currentDamage);
                }

                if (hit.transform.tag == "animal")
                {
                    hit.transform.GetComponent<animalEnemyAI>().TakeDammage(playerInv.currentDamage);
                }
    }

    public void AttackBarehanded()
    {

        RaycastHit hit;
        if (Physics.Raycast(rayHit.transform.position, transform.TransformDirection(Vector3.forward), out hit, attackRange))
        {
            Debug.DrawLine(rayHit.transform.position, hit.point, Color.red);
            // | hit.transform.tag == "team2"
            Damage(hit);
        }     
        
        deathRandom = Random.Range(0, 29);
        if (deathRandom == 0)
            animations.Play("Idle@Boxing");
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
            animations.Play("Foot11");
        if (deathRandom == 19)
            animations.Play("Foot2");
        if (deathRandom == 20)
            animations.Play("Foot3");
        if (deathRandom == 21)
            animations.Play("Foot4");
        if (deathRandom == 22)
            animations.Play("Foot5");
        if (deathRandom == 23)
            animations.Play("Foot6");
        if (deathRandom == 24)
            animations.Play("Foot7");
        if (deathRandom == 25)
            animations.Play("Foot8");
        if (deathRandom == 26)
            animations.Play("Foot9");
        if (deathRandom == 28)
            animations.Play("Foot10");
        if (deathRandom == 29)
            animations.Play("Head");
    }
}
