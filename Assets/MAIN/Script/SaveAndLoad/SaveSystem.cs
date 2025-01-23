using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    /// <summary>
    /// Saves the presets in binary
    /// </summary>
    /// <param name="gameManager"></param>
    public static void SavePlayer (WareManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/water.fill";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(gameManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    /// <summary>
    /// Load previous data
    /// </summary>
    /// <returns></returns>
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/water.fill";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;

        }
        else 
        {
            return null;

        }
    }

}
