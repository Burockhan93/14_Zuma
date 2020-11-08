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
    
    public void StarSpawn(LevelData levelData)
    {
        _pathData = levelData.path;
        StartJourney(_elementContainer);
    }
    private void StartJourney(ElementContainerModel elementContainer)
    {
    }
}