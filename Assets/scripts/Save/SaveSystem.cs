using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem  
{
    public static void SaveProgress(int lvl)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //string path = "D:/Games";
        string path = Application.persistentDataPath + "/zuMath.jaws";

        FileStream stream = new FileStream(path, FileMode.Create);

        DataToSave data = new DataToSave(lvl);

        formatter.Serialize(stream, data);
        stream.Close();

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
