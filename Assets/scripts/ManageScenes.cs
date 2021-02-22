using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScenes : MonoBehaviour
{
    public static ManageScenes instance;

    private DataToSave data;

    public void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Load();
    }

    public void Load()
    {
        data = SaveSystem.LoadProgress();
    }

    public DataToSave getData()
    {
        return data;
    }
}
