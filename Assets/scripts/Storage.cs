using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] private GameObject[] _digitPrefabs = new GameObject[10];
    public Dictionary<int, GameObject> allAlgebra = new Dictionary<int, GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        int Storage = _digitPrefabs.Length;
        for (int i = 0; i < Storage; i++)
        {
            allAlgebra.Add(i, _digitPrefabs[i]);  // bütün elemanlari bu dictionaryde topladik
        }
    }
}
