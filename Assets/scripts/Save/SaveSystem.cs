using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem  
{

    private static void Save(DataToSave data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //string path = "D:/Games";
        string path = Application.persistentDataPath + "/zuMath.jaws";

        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, ManageScenesSaves.data);
        stream.Close();
    }
    

    public static void SaveProgress(string uName,int lvl, int score )
    {
        ManageScenesSaves.data.saveProgress(uName,lvl,score);
        Save(ManageScenesSaves.data);
    }
    public static void SaveUser(string uName)
    {
        ManageScenesSaves.data.addUser(uName);
        ManageScenesSaves.data.addHighScore(uName, 100);
        Save(ManageScenesSaves.data);
    }
    public static void SaveHighScore(string uName, int highScore)
    {
        ManageScenesSaves.data.addHighScore(uName,highScore);
        Save(ManageScenesSaves.data);
    }


    public static DataToSave LoadProgress()
    {
        string path = Application.persistentDataPath + "/zuMath.jaws";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DataToSave data = formatter.Deserialize(stream) as DataToSave;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found " + path);
            return null;
        }
    }
}
