using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public static UnityEvent onLevelEnd =new UnityEvent();
    [SerializeField] private List<LevelData> _levelDatas;
    [SerializeField] private SpawnController _spawnController;

    private int currentLevel;
    private bool isLevelStarted=false;
    private LevelData _currentLevelData;
    public void Start()
    {
        currentLevel = 1;
        onLevelEnd.AddListener(() =>
        {
            Debug.Log("Level Bitti");
            EndLevel();
        });
    }

    private void Update()
    {
        if(isLevelStarted)
            return;
        if (Input.GetKeyDown("space"))
        {
            StartLevel();
            isLevelStarted = true;
        }
    }

    public void StartLevel()
    {
         _currentLevelData = _levelDatas.FirstOrDefault(x => x.levelId == currentLevel);
        
        _spawnController.StarSpawn(_currentLevelData);
    }

    public void EndLevel()
    {
        //LevelBitince olacaklar sıralanacak
        currentLevel++;
    }

    public PathData GetCurrentPath()
    {
        return _currentLevelData.path;
    }

    public int GetLevelDigitNumber()
    {
        return _currentLevelData.levelDigits.Count;
    }

    public float GetLevelTime()
    {
        return _currentLevelData.levelTime;
    }
    private void Restart()
    {
    }
}