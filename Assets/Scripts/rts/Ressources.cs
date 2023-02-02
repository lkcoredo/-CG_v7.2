using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Ressources : MonoBehaviour
{
    public Transform spawnPosK;
    public Transform spawnPosH;
    public GameObject spawneeKnight;
    public GameObject spawneeCampfire;
    public GameObject spawneeTente;
    public GameObject spawneeHutte;
    public GameObject spawneeMaison;
    public GameObject spawneeFerme;
    public GameObject spawneeChateau;
    public GameObject spawneePuit;
    public GameObject spawneeMoulin;
    public GameObject spawneeForge;
    public GameObject spawneeTaverne;
    public GameObject spawneeReserve;
    public GameObject spawneeVillageois;

    /*    public GameObject obj;*/
    public string inputKnight;
    public string inputCampfire;
    public string inputTente;
    public string inputHutte;
    public string inputMaison;
    public string inputFerme;
    public string inputChateau;
    public string inputPuit;
    public string inputMoulin;
    public string inputForge;
    public string inputTaverne;
    public string inputReserve;
    public string inputVillageois;

    //InputDialogue
    bool inputDialogue;
    public static Ressources Instance { get; private set; }

    public TextMeshProUGUI woodText;
    public int currentWood = 500;
    public int startWood = 500;

    public TextMeshProUGUI stoneText;
    public int currentStone = 500;
    public int startStone = 500;

    public TextMeshProUGUI metalText;
    public int currentMetal = 500;
    public int startMetal = 500;

    public TextMeshProUGUI laineText;
    public int currentLaine = 500;
    public int startLaine = 500;

    public TextMeshProUGUI rubyText;
    public int currentRuby = 500;
    public int startRuby = 500;

    public TextMeshProUGUI goldText;
    public int currentGold = 500;
    public int startGold = 500;

    public TextMeshProUGUI populationText;
    public int currentPopulation = 500;
    public int startPopulation = 500;

    public TextMeshProUGUI populariteText;
    public int currentPopularite = 500;
    public int startPopularite = 500;

    public TextMeshProUGUI reputationText;
    public int currentReputation = 500;
    public int startReputation = 500;

    public TextMeshProUGUI rationText;
    public int currentRation = 500;
    public int startRation = 500;

    bool rtsVisible = true;
    bool cinemaVisible = true;
    bool detailpersoVisible = true;
    bool mouseVisible = false;

    public Image imgCampfire;
    public Image imgTente;
    public Image imgCabane;
    public Image imgMaison;
    public Image imgFerme;
    public Image imgGrenier;
    public Image imgMoulin;
    public Image imgPuit;
    public Image imgForge;
    public Image imgAuberge;
    public Image imgChateau;

    private void Awake()
    {
        currentWood = startWood;
        currentStone = startStone;
        currentMetal = startMetal;
        currentLaine = startLaine;
        currentGold = startGold;
        currentPopulation = startPopulation;
        currentPopularite = startPopularite;
        currentReputation = startReputation;
        currentRation = startRation;

        Instance = this;
    }

    private void FixedUpdate()
    {
        woodText.text = "" + currentWood.ToString();
        stoneText.text = "" + currentStone.ToString();
        metalText.text = "" + currentMetal.ToString();
        laineText.text = "" + currentLaine.ToString();
        goldText.text = "" + currentGold.ToString();
        populationText.text = "" + currentPopulation.ToString();
        populariteText.text = "" + currentPopularite.ToString();
        reputationText.text = "" + currentReputation.ToString();
        rationText.text = "" + currentRation.ToString();
    }

    public void ConstruireCampfire()
    {
        if (currentWood > 10 && inputDialogue == false)
        {
            Instantiate(spawneeCampfire, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 10;
        }
        else 
        {
            print("Vous n'avez pas assez de ressources");
        }
    }

    public void ConstruireTente()
    {
        if (currentWood > 50 && inputDialogue == false)
        {
            Instantiate(spawneeTente, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 50;
        }
        else 
        {
            print("Vous n'avez pas assez de ressources");
        }
    }

    public void ConstruireCabane()
    {
        if (currentWood > 100 && inputDialogue == false)
        {
            Instantiate(spawneeHutte, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 100;
        }
        else 
        {
            print("Vous n'avez pas assez de ressources");
        }
    }

    public void ConstruireMaison()
    {
        if (currentWood > 200 && inputDialogue == false)
        {
            Instantiate(spawneeMaison, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 200;
        }
        else 
        {
            print("Vous n'avez pas assez de ressources");
        }

    }

    public void ConstruireFerme()
    {
        if (currentWood > 200 && inputDialogue == false)
        {
            Instantiate(spawneeFerme, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 200;
        }
        else 
        {
            print("Vous n'avez pas assez de ressources");
        }

    }

    public void ConstruireGrenier()
    {
        if (currentWood > 10 && inputDialogue == false)
        {
            Instantiate(spawneeReserve, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 10;
        }
        else 
        {
            print("Vous n'avez pas assez de ressources");
        }
    }

    public void ConstruireMoulin()
    {
        if (currentWood > 200 && inputDialogue == false)
        {
            Instantiate(spawneeMoulin, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 200;
        }
        else 
        {
            print("Vous n'avez pas assez de ressources");
        }
    }

    public void ConstruirePuit()
    {
        if (currentWood > 100 && inputDialogue == false)
        {
            Instantiate(spawneePuit, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 100;
        }
        else 
        {
            print("Vous n'avez pas assez de ressources");
        }
    }

    public void ConstruireForge()
    {
        if (currentWood > 200 && inputDialogue == false)
        {
            Instantiate(spawneeForge, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 200;
        }
        else 
        {
            print("Vous n'avez pas assez de ressources");
        }
    }

    public void ConstruireAuberge()
    {
        if (currentWood > 200 && inputDialogue == false)
        {
            Instantiate(spawneeTaverne, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 200;
        }
        else 
        {
            print("Vous n'avez pas assez de ressources");
        }
    }

    public void ConstruireChateau()
    {
        if (currentWood > 1000 && inputDialogue == false)
        {
            Instantiate(spawneeChateau, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 1000;
        }
        else 
        {
            print("Vous n'avez pas assez de ressources");
        }
    }

    public void RecruterVillagois()
    {
        if (currentGold > 10 && inputDialogue == false)
        {
            Instantiate(spawneeVillageois, spawnPosH.position, spawnPosH.rotation);
            currentGold = currentGold - 10;
        } 
        else 
        {
            print("Vous n'avez pas assez d'argent");
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        inputDialogue = false;
        InvokeRepeating("UpdateEating", 10f, 1f);
    }

    void UpdateEating()
    {
        currentRation = currentRation - currentPopulation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (mouseVisible == true) // Hide mouse
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                mouseVisible = false;
            }
            else if (mouseVisible == false) // Show mouse
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                mouseVisible = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.H) && inputDialogue == false)
        {
            if (rtsVisible == true) // Hide button
            {
                GameObject.Find("RTS").transform.localScale = new Vector3(0, 0, 0);
                rtsVisible = false;
            } 
            else if (rtsVisible == false) // Show button
            {
                GameObject.Find("RTS").transform.localScale = new Vector3(1, 1, 1);
                rtsVisible = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.V) && inputDialogue == false)
        {
            if (cinemaVisible == true) // Hide button
            {
                GameObject.Find("cinema").transform.localScale = new Vector3(0, 0, 0);
                cinemaVisible = false;
            }
            else if (cinemaVisible == false) // Show button
            {
                GameObject.Find("cinema").transform.localScale = new Vector3(1, 1, 1);
                cinemaVisible = true;
            }
        }

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //if (detailpersoVisible == true) // Hide button
        //{
        //     GameObject.Find("detailperso").transform.localScale = new Vector3(0, 0, 0);
        //     detailpersoVisible = false;
        //}
        //else if (cinemaVisible == false) // Show button
        //{
        //GameObject.Find("detailperso").transform.localScale = new Vector3(1, 1, 1);
        //detailpersoVisible = true;
        //}
        //}

        if (Input.GetKeyDown(KeyCode.F) && inputDialogue == false)
        {
            inputDialogue = true;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputDialogue = false;
        }

        if (Input.GetKey(inputKnight) && currentWood > 50 && inputDialogue == false)
        {
            Instantiate(spawneeKnight, spawnPosK.position, spawnPosK.rotation);
            currentWood = currentWood - 50;
        }

        if (Input.GetKeyDown(KeyCode.B) && inputDialogue == false)
        {
            print("test_spawn_villageois");
            Instantiate(spawneeVillageois, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 10;
        }

        if (Input.GetKey(inputCampfire) && currentWood > 10 && inputDialogue == false)
        {
            Instantiate(spawneeCampfire, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 10;
            /* spawnPosH.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
             Vector3 newPosition = new Vector3(20, 20, 20);
             spawnPosH.transform.position = newPosition;*/
            /*Vector3 newRotation = new Vector3(-90, 0, 0);
            spawnPosH.transform.eulerAngles = newRotation;*/
        }

        if (Input.GetKey(inputTente) && currentWood > 50 && inputDialogue == false)
        {
            Instantiate(spawneeTente, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 50;
        }

        if (Input.GetKey(inputHutte) && currentWood > 100 && inputDialogue == false)
        {
            Instantiate(spawneeHutte, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 100;
        }


        if (Input.GetKey(inputMaison) && currentWood > 200 && inputDialogue == false)
        {
            Instantiate(spawneeMaison, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 200;
        }

        if (Input.GetKey(inputFerme) && currentWood > 200 && inputDialogue == false)
        {
            Instantiate(spawneeFerme, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 200;
        }

        if (Input.GetKey(inputChateau) && currentWood > 1000 && inputDialogue == false)
        {
            Instantiate(spawneeChateau, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 1000;
        }

        if (Input.GetKey(inputPuit) && currentWood > 100 && inputDialogue == false)
        {
            Instantiate(spawneePuit, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 100;
        }

        if (Input.GetKey(inputMoulin) && currentWood > 200 && inputDialogue == false)
        {
            Instantiate(spawneeMoulin, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 200;
        }

        if (Input.GetKey(inputForge) && currentWood > 200 && inputDialogue == false)
        {
            Instantiate(spawneeForge, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 200;
        }

        if (Input.GetKey(inputTaverne) && currentWood > 200 && inputDialogue == false)
        {
            Instantiate(spawneeTaverne, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 200;
        }

        if (Input.GetKey(inputReserve) && currentWood > 10 && inputDialogue == false)
        {
            Instantiate(spawneeReserve, spawnPosH.position, spawnPosH.rotation);
            currentWood = currentWood - 10;
        }

        if (Input.GetKeyDown(KeyCode.Y) && inputDialogue == false)
        {
            currentWood = currentWood + 100;
        }
    }
}
