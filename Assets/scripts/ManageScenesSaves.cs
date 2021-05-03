using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScenesSaves : MonoBehaviour
{
    public static ManageScenesSaves instance;
    public static string UserName;
    public static DataToSave data; // save dosyasina dokunmamak icin buraya örnegi aldik bunu degstrp yükleycez

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            data = SaveSystem.LoadProgress();
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    public Dictionary<string, int[]> getData()
    {
                
        //Dictionary<string, int[]> users = data.Users1;
        return data.Users1;
    }
}
