using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _digitPrefabs; 
    public static Dictionary<int, GameObject> allAlgebra = new Dictionary<int, GameObject>();
    

    private float distance = 1f;
    private ElementContainerController _elementContainer;
    private PathData _pathData;
    private int numberOfElement;

    private List<AlgebraModel> model;
    

    
    public Transform a;  //Inspectordan bir küpü koydum degisebilir

    private void Start()
    {
        int Storage = _digitPrefabs.Count;
        for (int i=0; i < Storage; i++)
        {
            allAlgebra.Add(i, _digitPrefabs[i]);  // bütün elemanlaribu dictionaryde topladik
        }
        

        _elementContainer = FindObjectOfType<ElementContainerController>();

    }

    public void StarSpawn(LevelData levelData)
    {
        _pathData = levelData.path;
        numberOfElement = levelData.levelDigits.Count;

        model = (ModelstoSpawn(levelData.levelDigits));

        StartJourney(_elementContainer,model);
    }
    private void StartJourney(ElementContainerController elementContainer, List<AlgebraModel> model)
    {
        StartCoroutine(_makeaList(elementContainer, model));
        
    }

    private List<AlgebraModel> ModelstoSpawn(List<int> levelDigits)
    {
        
        List<AlgebraModel> modelstospwan = new List<AlgebraModel>();

        
        foreach (int i in levelDigits)
        {
            modelstospwan.Add(new AlgebraModel(i, _digitPrefabs[i]));
            //switch (levelDigits[i])
            //{

            //    case 1:
                   
            //        modelstospwan.Add(new AlgebraModel(1, _digitPrefabs[0]));
                    
            //        break;
            //    case 2:
            //        modelstospwan.Add(new AlgebraModel(2, _digitPrefabs[1]));
                    
            //        break;
            //    case 3:
            //        modelstospwan.Add(new AlgebraModel(3, _digitPrefabs[2]));
                    
            //        break;
            //    case 4:
            //        modelstospwan.Add(new AlgebraModel(4, _digitPrefabs[3]));
                   
            //        break;
            //}
        }
        return modelstospwan;
    }

    private IEnumerator _makeaList(ElementContainerController elementContainer, List<AlgebraModel> model)
    {
        
        for (int i = 0; i < numberOfElement; i++)
        {
            elementContainer.AddElement(Instantiate(a, _pathData.paths[0], Quaternion.identity),model[i]);
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Coroutne");
        
    }
}