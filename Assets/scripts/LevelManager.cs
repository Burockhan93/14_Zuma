using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<LevelData> _levelDatas;
    [SerializeField] private SpawnController _spawnController;

    private int currentLevel;

    private void Start()
    {
        currentLevel = 1;
    }

    private void StartLevel()
    {
        var currentLevelData = _levelDatas.FirstOrDefault(x => x.levelId == currentLevel);
         _spawnController.StarSpawn(currentLevelData);
    }

    private void EndLevel()
    {
        currentLevel++;
    }

    private void Restart()
    {
    }
}