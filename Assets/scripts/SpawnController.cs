using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _digitPrefabs;
    
    private float distance = 1f;
    private ElementContainerModel _elementContainer;
    private PathData _pathData;
    private int numberOfElement;

    private List<IHoldable> _digits;


    
    public Transform a;

    private void Start()
    {
        _elementContainer = FindObjectOfType<ElementContainerModel>();
        
    }

    public void StarSpawn(LevelData levelData)
    {
        _pathData = levelData.path;

        numberOfElement = levelData.levelDigits.Count;

        StartJourney(_elementContainer);
    }
    private void StartJourney(ElementContainerModel elementContainer)
    {
        StartCoroutine(_makeaList(elementContainer));
        
    }

    private IEnumerator _makeaList(ElementContainerModel elementContainer)
    {
        for (int i = 0; i < numberOfElement; i++)
        {

            //elementContainer.items[i]= Instantiate(a, _pathData.paths[0], Quaternion.identity);
            elementContainer.AddElement(Instantiate(a, _pathData.paths[0], Quaternion.identity));
            
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("Coroutne");
        //yield return new WaitForSeconds(0.5f);
    }
}