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
    [SerializeField] private GameObject _endLevelMenu;
    [SerializeField] private Score __level;


    public static int currentLevel;
    private bool isLevelStarted=false;
    private LevelData _currentLevelData;
    private AlgebraDestroyer _algebraDestroyer;

    


   
    public void Start()
    {

        if (currentLevel == 0) currentLevel = 1;

        _algebraDestroyer = GetComponent<AlgebraDestroyer>();
        
        
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
       //  _currentLevelData = _levelDatas.FirstOrDefault(x => x.levelId == currentLevel);
        
        _currentLevelData = _levelDatas[currentLevel-1]; //liste 0 dan basladigi icin -1
        __level.Level(currentLevel);

        if (_currentLevelData.levelId==12) FindObjectOfType<AudioManager>().PlayTheme("ThemeFinal");

        _spawnController.StartSpawn(_currentLevelData);
    }

    public void EndLevel()
    {
        //LevelBitince olacaklar sıralanacak

        //SaveGame(currentLevel);

        _algebraDestroyer.DestroyEverything();

        

        _endLevelMenu.SetActive(true);
        

        //currentLevel++;
        isLevelStarted = false;
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