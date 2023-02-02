using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int health;
    public float[] position;
    public int position_arbreX;
    public int position_arbreZ;
    public int rotation_arbre;
    public int position_villageX;
    public int position_villageZ;
    public int rotation_village;
    public int crime;
    public bool existence_village;
    public int codeTerrain;


    public PlayerData(Player player)
    {
        level = player.level;
        health = player.health;
        position_arbreX = player.position_arbreX;
        position_arbreZ = player.position_arbreZ;
        rotation_arbre = player.rotation_arbre;

        //village
        position_villageX = player.position_villageX;
        position_villageZ = player.position_villageZ;
        rotation_village = player.rotation_village;
        existence_village = player.existence_village;
        crime = player.crime;

        //terrain
        codeTerrain = player.codeTerrain;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
