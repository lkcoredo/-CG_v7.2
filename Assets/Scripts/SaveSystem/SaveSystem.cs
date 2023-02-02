using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    const string SAVE_DIR = "Assets/StoredData/";

    public static void SavePlayer(Player player, string tyx)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        /*string path = Application.persistentDataPath + "/player.luk";*/
        var path = SAVE_DIR + tyx + "save.dat";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);
        /*stream.Position = 0;*/
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer(string tyx)
    {
        /*string path = Application.persistentDataPath + "/player.luk";*/
        var path = SAVE_DIR + tyx + "save.dat";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            /*stream.Position = 0;*/
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }



}
