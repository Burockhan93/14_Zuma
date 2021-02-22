using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
        
    private ElementContainerController elementContainer;
    
    private PathData _pathData;
    private int numberOfElement;
    private List<int> models;

    private GameObject a; //Transform yaratmak icin sahneye
    private Transform _a;

    private float _creationSpeed;
    

    void Start()
    {
        _creationSpeed = 1f;

        a = new GameObject();
        _a = a.transform; 

       elementContainer = FindObjectOfType<ElementContainerController>();
    }

    public void StartSpawn(LevelData levelData)
    {
        _pathData = levelData.path;
        numberOfElement = levelData.levelDigits.Count;
        models = levelData.levelDigits;

        StartCoroutine(_makeaList(elementContainer, models));
    }
   
    private IEnumerator _makeaList(ElementContainerController elementContainer, List<int> models)
    {
        for (int i = 0; i < numberOfElement; i++)
        {
            elementContainer.AddElement(Instantiate(_a, _pathData.paths[0], Quaternion.identity), models[i]);

            yield return new WaitForSeconds(_creationSpeed);
        }
        Debug.Log("Coroutne");

    }
}