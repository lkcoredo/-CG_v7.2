using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{

    public int level = 8;
    public int health = 20;
    public int position_arbreX = 0;
    public int position_arbreZ = 0;
    public int rotation_arbre = 0;
    public int position_villageX = 0;
    public int position_villageZ = 0;
    public int rotation_village = 0;
    public int crime = 0;
    public bool existence_village = false;
    public int codeTerrain = 0;

    public void SavePlayer(string tyx)
    {
        SaveSystem.SavePlayer(this, tyx);
    }

    public void LoadPlayer(string tyx)
    {
        PlayerData data = SaveSystem.LoadPlayer(tyx);

        level = data.level;
        health = data.health;
        position_arbreX = data.position_arbreX;
        position_arbreZ = data.position_arbreZ;
        rotation_arbre = data.rotation_arbre;

        //terrain
        codeTerrain = data.codeTerrain;

        //village
        position_villageX = data.position_villageX;
        position_villageZ = data.position_villageZ;
        rotation_village = data.rotation_village;
        existence_village = data.existence_village;
        
        crime = data.crime;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

}











/*    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J))
        {
            string tyx = "XXX";
            SavePlayer(tyx);
            print("Game saved ! (Player)");
        }


        if (Input.GetKeyDown(KeyCode.L))
        {
            string tyx = "XXX";
            LoadPlayer(tyx);
            print("Game loaded ! (Player)");
        }
    }*/