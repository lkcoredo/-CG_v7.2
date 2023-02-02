using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using Random = System.Random;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEditor;

//      https://answers.unity.com/questions/260100/instantiate-as-a-child-of-the-parent.html

public class Procedural : MonoBehaviour
{
    public OnTriggerSud triggerSud;
    public OnTriggerNord triggerNord;
    public OnTriggerEst triggerEst;
    public OnTriggerOuest triggerOuest;
    [SerializeField] private Material myMaterial;

	public Transform spawnPosTerrain;
	public GameObject spawneeTree;
    public GameObject spawneeRepaire;
    public GameObject parent;
    public Transform spawnPosBandit;

    public GameObject carrefour;
    public GameObject grandePlaine;
    public GameObject toitsDuMonde;
    public GameObject foretProfonde;
    public GameObject hauteMontagne;
    public GameObject petiteMontagne;
    public GameObject collines;
    public GameObject foretdeHauteMontagne;
    public GameObject foretdeMontagne;
    public GameObject foretProfondesurColline;
    public GameObject bosquet;
    public GameObject clairiere;
    public GameObject foret;
    public GameObject desertProfond;
    public GameObject desert;
    public GameObject dunes;

    //TerrainRandom
    public GameObject spawneeTerrainPlaineA;

    const string SAVE_DIR = "Assets/StoredData/";
	/* string path = Application.persistentDataPath + "/player.fun" */
	/*const string SAVE_DIR = "user://saves/"*/
	/*string save_path = SAVE_DIR + "save.dat";*/

	public GameObject Terrain;
	public GameObject spawneeMessager;
    public GameObject spawneeVillage;

    //InputDialogue
    bool inputDialogue;

    Iteration n1 = new Iteration(0);
    Joueur mon_joueur = new Joueur("lukas", 0, 0);

    [SerializeField]
    private int lastScore = 0;

    public bool onetime = true;

	public Player player;
    /*    public int level = 3;
        public int health = 40;*/

    public class Joueur
    {
        public string Nom;
        public int LocX;
        public int LocY;

        public Joueur(string nom, int locX, int locY)
        {
            Nom = nom;
            LocX = locX;
            LocY = locY;
        }
    }

    public class Iteration
    {
        public int n;

        public Iteration(int value)
        {
            int n = value;
        }

        public int _iter()
        {
            return n;
        }

        public void _next()
        {
            n += 1;
        }
    }

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inputDialogue == false)
        {
            inputDialogue = true;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputDialogue = false;
        }

        if (Input.GetKeyDown(KeyCode.J) && inputDialogue == false)
        {
            string tyx = "XXX";
            player.SavePlayer(tyx);
            print("Game saved ! (Procedural) : " + tyx);
        }


        if (Input.GetKeyDown(KeyCode.L) && inputDialogue == false)
        {
            string tyx = "XXX";
            player.LoadPlayer(tyx);
            print("Game loaded ! (Procedural)" + tyx);
        }

        if (triggerSud.sudEnter == true) { }
        if (triggerNord.nordEnter == true) { }
        if (triggerEst.estEnter == true) { }
        if (triggerOuest.ouestEnter == true) { }

        /*		if (Input.GetKeyDown(KeyCode.A))
                {
                    GameObject.Find("Player").transform.position = new Vector3(236.57f, -100f, 247.83f);
                    Terrain.SetActive(false);
                }


                if (Input.GetKeyDown(KeyCode.Y))
                {
                    GameObject.Find("Player").transform.position = new Vector3(236.57f, -100f, 247.83f);
                    Terrain.SetActive(true);
                }*/


    }

    private void Start()
    {
        /*generer_monde();*/
        inputDialogue = false;
        OnTriggerSud.current.onTriggerEnterSud += onTriggerEnterProceduralSud;
        OnTriggerNord.current.onTriggerEnterNord += onTriggerEnterProceduralNord;
        OnTriggerOuest.current.onTriggerEnterOuest += onTriggerEnterProceduralOuest;
        OnTriggerEst.current.onTriggerEnterEst += onTriggerEnterProceduralEst;
/*        print("n1 : " + n1);
        print("mon_joueur : " + mon_joueur);
        print("\n" + "Vous êtes actuellement en " + mon_joueur.LocX + "/" + mon_joueur.LocY);*/

        PlayerPrefs.SetInt("Score", 25);
        lastScore = PlayerPrefs.GetInt("Score");
        /*Debug.Log("lastScore : " + lastScore);*/
    }

    private void onTriggerEnterProceduralSud()
    {
        /*print("(Evenement declenché!) Vous êtes en cours de voyage dans le sud...");*/
        var X = mon_joueur.LocX;
        var Y = mon_joueur.LocY;
        Y -= 1;
        mon_joueur.LocX = X;
        mon_joueur.LocY = Y;
        GameObject.Find("Player").transform.position = new Vector3(800, -200f, 2100);
        generer_monde();
    }

    private void onTriggerEnterProceduralNord()
    {
        /*print("(Evenement declenché!) Vous êtes en cours de voyage dans le nord...");*/
        var X = mon_joueur.LocX;
        var Y = mon_joueur.LocY;
        Y += 1;
        mon_joueur.LocX = X;
        mon_joueur.LocY = Y;
        GameObject.Find("Player").transform.position = new Vector3(800, -200f, -600);
        generer_monde();
    }

    private void onTriggerEnterProceduralOuest()
    {
        /*print("(Evenement declenché!) Vous êtes en cours de voyage dans l'ouest...");*/
        var X = mon_joueur.LocX;
        var Y = mon_joueur.LocY;
        X -= 1;
        mon_joueur.LocX = X;
        mon_joueur.LocY = Y;
        GameObject.Find("Player").transform.position = new Vector3(2100, -200f, 650);
        generer_monde();
    }

    private void onTriggerEnterProceduralEst()
    {
        /*print("(Evenement declenché!) Vous êtes en cours de voyage dans l'est...");*/
        var X = mon_joueur.LocX;
        var Y = mon_joueur.LocY;
        X += 1;
        mon_joueur.LocX = X;
        mon_joueur.LocY = Y;
        GameObject.Find("Player").transform.position = new Vector3(-650, -200f, 650);
        generer_monde();
    }

    public void generer_monde()
    {
        FindObjectOfType<Livings>().remove_all();

        StopCoroutine(addCrime());
        StartCoroutine(addCrime());

        carrefour = GameObject.Find("/map/procedural/Carrefour"); //1
        grandePlaine = GameObject.Find("/map/procedural/GrandePlaine"); //2
        toitsDuMonde = GameObject.Find("/map/procedural/ToitsduMonde"); //3
        foretProfonde = GameObject.Find("/map/procedural/ForetProfonde"); //4
        hauteMontagne = GameObject.Find("/map/procedural/HauteMontagne"); //5
        petiteMontagne = GameObject.Find("/map/procedural/PetiteMontagne"); //6
        collines = GameObject.Find("/map/procedural/Collines"); //7
        foretdeHauteMontagne = GameObject.Find("/map/procedural/ForetdeHauteMontagne"); //8
        foretdeMontagne = GameObject.Find("/map/procedural/ForetdeMontagne"); //9
        foretProfondesurColline = GameObject.Find("/map/procedural/ForetProfondeenColline"); //10
        bosquet = GameObject.Find("/map/procedural/Bosquet"); //11
        clairiere = GameObject.Find("/map/procedural/Clairiere"); //12
        foret = GameObject.Find("/map/procedural/Foret"); //13
        desertProfond = GameObject.Find("/map/procedural/DesertProfond"); //14
        desert = GameObject.Find("/map/procedural/Desert"); //15
        dunes = GameObject.Find("/map/procedural/Dunes"); //16

        GameObject[] hostiles = GameObject.FindGameObjectsWithTag("hostile");
        foreach (GameObject hostile in hostiles)
            GameObject.Destroy(hostile);

        GameObject[] procedurals = GameObject.FindGameObjectsWithTag("procedural");
        foreach (GameObject procedural in procedurals)
            //StartCoroutine(Destroy(procedural));
            GameObject.Destroy(procedural);

        GameObject[] terrains = GameObject.FindGameObjectsWithTag("Terrain");
        foreach (GameObject terrain in terrains)
            StartCoroutine(SetInactive(terrain));
            //terrain.SetActive(false);

        GameObject[] team1s = GameObject.FindGameObjectsWithTag("team1");
        foreach (GameObject team1 in team1s)
            GameObject.Destroy(team1);

        GameObject[] team2s = GameObject.FindGameObjectsWithTag("team2");
        foreach (GameObject team2 in team2s)
            GameObject.Destroy(team2);

        GameObject[] neutres = GameObject.FindGameObjectsWithTag("neutre");
        foreach (GameObject neutre in neutres)
            GameObject.Destroy(neutre);

        GameObject[] messagers = GameObject.FindGameObjectsWithTag("messager");
        foreach (GameObject messager in messagers)
            GameObject.Destroy(messager);

        GameObject[] equipes = GameObject.FindGameObjectsWithTag("equipe");
        foreach (GameObject equipe in equipes)
            GameObject.Destroy(equipe);

        /*Debug.Log("Taux de criminalité dans la région : " + player.crime);*/


        print("\n" + "Vous êtes arrivé en " + mon_joueur.LocX + "/" + mon_joueur.LocY);
        var t = n1._iter();
        /*print("t :" + t);*/
        string tx = "" + mon_joueur.LocX;
        string ty = "" + mon_joueur.LocY;
        string tyx = tx + "0" + ty;
        //verifier si le terrain existe à cette destination

        //+1 itération
        var iter = n1._iter();
        n1._next();
        var d = n1._iter();
        iter = d;
        var destination = mon_joueur.LocX + "0" + mon_joueur.LocY;

        var save_path_iter = SAVE_DIR + tyx + "save.dat";


      /*  print("save_path_iter : " + save_path_iter);*/
        /*var lieu_load = File.new();*/


        //le terrain existe...
        if (File.Exists(save_path_iter))
        {
            /*print("LE TERRAIN EXISTE !");*/

            player.LoadPlayer(tyx);
            /*print("Game loaded ! (Procedural Interne)");*/

            if (player.codeTerrain == 1) { carrefour.SetActive(true); }
            if (player.codeTerrain == 2) { grandePlaine.SetActive(true); }
            if (player.codeTerrain == 3) { toitsDuMonde.SetActive(true); }
            if (player.codeTerrain == 4) { foretProfonde.SetActive(true); }
            if (player.codeTerrain == 5) { hauteMontagne.SetActive(true); }
            if (player.codeTerrain == 6) { petiteMontagne.SetActive(true); }
            if (player.codeTerrain == 7) { collines.SetActive(true); }
            if (player.codeTerrain == 8) { foretdeHauteMontagne.SetActive(true); }
            if (player.codeTerrain == 9) { foretdeMontagne.SetActive(true); }
            if (player.codeTerrain == 10) { foretProfondesurColline.SetActive(true); }
            if (player.codeTerrain == 11) { bosquet.SetActive(true); }
            if (player.codeTerrain == 12) { clairiere.SetActive(true); }
            if (player.codeTerrain == 13) { foret.SetActive(true); }
            if (player.codeTerrain == 14) { desertProfond.SetActive(true); }
            if (player.codeTerrain == 15) { desert.SetActive(true); }
            if (player.codeTerrain == 16) { dunes.SetActive(true); }

            Quaternion load_quaternion = new Quaternion(0, player.rotation_arbre, 0, 0);
            /*Instantiate(spawneeTree, new Vector3(player.position_arbreX, -150, player.position_arbreZ), spawnPosTerrain.rotation);*/

            /*Instantiate(spawneeTree, new Vector3(500 + player.position_arbreX, -150, 100 + player.position_arbreZ), spawnPosTerrain.rotation);
            Instantiate(spawneeTree, new Vector3(200 + player.position_arbreX, -150, 800 + player.position_arbreZ), spawnPosTerrain.rotation);
            Instantiate(spawneeTree, new Vector3(500 + player.position_arbreX, -150, 600 + player.position_arbreZ), spawnPosTerrain.rotation);
            Instantiate(spawneeTree, new Vector3(100 + player.position_arbreX, -150, 300 + player.position_arbreZ), spawnPosTerrain.rotation);

            Instantiate(spawneeTree, new Vector3(150 + player.position_arbreX, -150, 550 + player.position_arbreZ), spawnPosTerrain.rotation);
            Instantiate(spawneeTree, new Vector3(850 + player.position_arbreX, -150, 250 + player.position_arbreZ), spawnPosTerrain.rotation);
            Instantiate(spawneeTree, new Vector3(650 + player.position_arbreX, -150, 150 + player.position_arbreZ), spawnPosTerrain.rotation);
            Instantiate(spawneeTree, new Vector3(550 + player.position_arbreX, -150, 550 + player.position_arbreZ), spawnPosTerrain.rotation);*/

            /*if (player.existence_village == true)
            {
                Instantiate(spawneeVillage, new Vector3(500 + player.position_villageX, -230, 500 + player.position_villageZ), spawnPosTerrain.rotation);
            }
            else
            {
            }*/

            


            int i = 0;
            // while loop execution
            /*Debug.Log("Repaire de bandit x" + player.crime);*/
            while (i < player.crime)
            {
                /*Debug.Log("Un Repaire de bandit a été découvert dans la région !...");*/
                Instantiate(spawneeRepaire, new Vector3(700 + player.position_arbreX, -150, 700 + player.position_arbreZ), spawnPosTerrain.rotation);
                i++;
            }

        }
        else // si le terrain n'existe pas...
        {
            /*print("LE TERRAIN N'EXISTE PAS!");*/
            /*print("le fichier lieu_load itération : " + tyx + " n'existe pas ! ");
			print("création du fichier...");*/

            Random rnd_terrain = new Random();
            int random_int_terrain = rnd_terrain.Next(1, 16);

            if (random_int_terrain == 1) { carrefour.SetActive(true); }
            if (random_int_terrain == 2) { grandePlaine.SetActive(true); }
            if (random_int_terrain == 3) { toitsDuMonde.SetActive(true); }
            if (random_int_terrain == 4) { foretProfonde.SetActive(true); }
            if (random_int_terrain == 5) { hauteMontagne.SetActive(true); }
            if (random_int_terrain == 6) { petiteMontagne.SetActive(true); }
            if (random_int_terrain == 7) { collines.SetActive(true); }
            if (random_int_terrain == 8) { foretdeHauteMontagne.SetActive(true); }
            if (random_int_terrain == 9) { foretdeMontagne.SetActive(true); }
            if (random_int_terrain == 10) { foretProfondesurColline.SetActive(true); }
            if (random_int_terrain == 11) { bosquet.SetActive(true); }
            if (random_int_terrain == 12) { clairiere.SetActive(true); }
            if (random_int_terrain == 13) { foret.SetActive(true); }
            if (random_int_terrain == 14) { desertProfond.SetActive(true); }
            if (random_int_terrain == 15) { desert.SetActive(true); }
            if (random_int_terrain == 16) { dunes.SetActive(true); }

            player.codeTerrain = random_int_terrain;

            int random_PositionArbreX = random_position3D();
            int random_PositionArbreZ = random_position3D();
            int random_rotationArbre = random_rotation3D();
            Quaternion random_quaternionArbre = new Quaternion(0, random_rotationArbre, 0, 0);
            player.position_arbreX = random_PositionArbreX;
            player.position_arbreZ = random_PositionArbreZ;
            player.rotation_arbre = random_rotationArbre;

            int random_PositionVillageX = random_position3D();
            int random_PositionVillageZ = random_position3D();
            int random_rotationVillage = random_rotation3D();
            Quaternion random_quaternionVillage = new Quaternion(0, random_rotationVillage, 0, 0);
            player.position_villageX = random_PositionVillageX;
            player.position_villageZ = random_PositionVillageZ;
            player.rotation_village = random_rotationVillage;
            bool resultat_existence_village = random_boolean(30);
            player.existence_village = resultat_existence_village;
            /*     transform.Rotate(rotx, roty, rotz);*/
            player.SavePlayer(tyx);
            /*print("Game saved ! (Procedural Interne)");*/

            /*int random_PositionArbre_int = Int16.Parse(random_PositionArbre1);*/
            /*Instantiate(spawneeTree, new Vector3(500 + random_PositionArbreX, -150, 100 + random_PositionArbreZ), spawnPosTerrain.rotation);
            Instantiate(spawneeTree, new Vector3(200 + random_PositionArbreX, -150, 800 + random_PositionArbreZ), spawnPosTerrain.rotation);
            Instantiate(spawneeTree, new Vector3(500 + random_PositionArbreX, -150, 600 + random_PositionArbreZ), spawnPosTerrain.rotation);
            Instantiate(spawneeTree, new Vector3(100 + random_PositionArbreX, -150, 300 + random_PositionArbreZ), spawnPosTerrain.rotation);

            Instantiate(spawneeTree, new Vector3(150 + random_PositionArbreX, -150, 550 + random_PositionArbreZ), spawnPosTerrain.rotation);
            Instantiate(spawneeTree, new Vector3(850 + random_PositionArbreX, -150, 250 + random_PositionArbreZ), spawnPosTerrain.rotation);
            Instantiate(spawneeTree, new Vector3(650 + random_PositionArbreX, -150, 150 + random_PositionArbreZ), spawnPosTerrain.rotation);
            Instantiate(spawneeTree, new Vector3(550 + random_PositionArbreX, -150, 550 + random_PositionArbreZ), spawnPosTerrain.rotation);*/

            /*Instantiate(spawneeMessager, new Vector3(174, -80, 260), spawnPosTerrain.rotation);*/
            Instantiate(spawneeMessager, spawnPosBandit.position, spawnPosBandit.rotation);
            FindObjectOfType<Livings>().add_messager();
            Debug.Log("Un messager s'approche de vous !");

            
           /* if (resultat_existence_village == true)
            {
                Instantiate(spawneeVillage, new Vector3(500 + random_PositionVillageX, -230, 500 + random_PositionVillageZ), spawnPosTerrain.rotation);
                Debug.Log("Il y a un village sur la map !");
            } else
            {
                Debug.Log("Aucun village");
            }*/
            
            

            int i = 0;
            // while loop execution
            /*Debug.Log("Repaire de bandit (" + player.crime + ")");*/
            while (i < player.crime)
            {
                /*Debug.Log("Un Repaire de bandit a été découvert dans la région !...");*/
                Instantiate(spawneeRepaire, new Vector3(700 + random_PositionArbreX, -150, 700 + random_PositionArbreZ), spawnPosTerrain.rotation);
                i++;
            }

            
        }
    }

        //sauvegarder terrain
        //supprimer ancien terrain

        //charger terrain OU...

        //creer terrain
        //creer un arbre
        //creer une montagne
        //creer les plantes
        //creer les textures
        //creer les animaux
        //creer une civilisation... etc.
        //creer une diplomatie...




    IEnumerator Destroy(GameObject go)
	{
		yield return new WaitForEndOfFrame();
		DestroyImmediate(go);
	}

    IEnumerator SetInactive(GameObject go)
    {
        yield return new WaitForEndOfFrame();
        go.SetActive(false);
    }

    public int random_position3D()
	{
		Random rnd = new Random();
		int random_int = rnd.Next(0, 800); 
		return random_int;
	}	

    public int random_rotation3D()
    {
        Random rnd = new Random();
        int random_int = rnd.Next(0, 30);
        return random_int;
    }

    public bool random_boolean(int proba)
    {
        Random rnd = new Random();
        int random_int = rnd.Next(0, 100);
        if (random_int >= proba)
        {
            return true;
        } else
        {
            return false;
        }
    }

    IEnumerator addCrime()
    {
        while (true)
        {
            player.crime++;
            /*Debug.Log("La criminalité augmente... (" + player.crime + ")");*/
            yield return new WaitForSeconds(100);
        }
    }
}
