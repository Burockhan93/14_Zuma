using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.UIElements;
using UnityEngine;


public class ElementContainerController : MonoBehaviour
{
    public static List<Transform> items = new List<Transform>(); // element container leveldataya bilgi vermesi lazimki her levelda kac item üretileccegi bilinsin
        
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private AlgebraAdder _algebraAdder;

    private int createdItemCount = 0;
    
    private int IndextoReturn; // buraya da bakilacak listede yok olan iki elemannin yerine yeni prefab eklenecegi zaman caöiisiyor.

    private void Awake()
    {  
        LevelManager.onLevelEnd.AddListener(() =>
        {
            createdItemCount = 0;
            
        });
    }

    public void AddElement(Transform element, int models)
    {

        items.Add(element);

        _algebraAdder.AddAlgebra(models);

        var j = items.Count;

        var path = _levelManager.GetCurrentPath();
        var levelTime = _levelManager.GetLevelTime();
        var itemNumber = _levelManager.GetLevelDigitNumber();
        FollowPath(path, items[j - 1], levelTime, itemNumber);

    }

   

    private void FollowPath(PathData getCurrentPath, Transform elementCont, float levelTime, int getLevelDigitNumber)
    {
        createdItemCount++;
        var itemNumber = _levelManager.GetLevelDigitNumber();
        var temp = itemNumber == createdItemCount;
        if (temp)
        {
            elementCont.DOPath(getCurrentPath.paths.ToArray(),  levelTime - getLevelDigitNumber)
                .SetEase(Ease.Linear)
                .OnComplete(() => LevelManager.onLevelEnd.Invoke()); //invokes the EndLevel in LevelManager
        }
        else
        {
            elementCont.DOPath(getCurrentPath.paths.ToArray(), levelTime - getLevelDigitNumber)
                .SetEase(Ease.Linear);
        }

    }


    public Transform GetElement(int index)
    {
        //TODO Bug
        return items[index];
    }

    public List<Transform> GetNearestTwoTransforms(Vector3 point) // infinity yerine 5f kullandik gelistirilebilir
    {
        List<Transform> nearestPoints = new List<Transform>();
        Dictionary<int,float> liste = new Dictionary<int, float>();

        int nearestIndex = 0;
        int secNearestIndex = 0;


        //float nearestDistance = Mathf.Infinity;
        //float secNearestDistance = Mathf.Infinity;

        //float distance = 5;
        //float distance1 = 5f;



        for (int i=0; i < items.Count; i++)
        {
            liste.Add(i, Vector3.Distance(items[i].position, point));
            
        }

        //float a = Mathf.Infinity;
        //float b = Mathf.Infinity;
        float a = 3;
        float b = 3;

        foreach (KeyValuePair<int,float> mallik in liste)
        {
            if (mallik.Value < a)
            {
                a = mallik.Value;
                nearestIndex = mallik.Key;
            }
            
        }

        liste[nearestIndex] = Mathf.Infinity;

        foreach (KeyValuePair<int, float> mallik in liste)
        {
            if (mallik.Value < b)
            {
                b = mallik.Value;
                secNearestIndex = mallik.Key;
            }

        }
        if (Mathf.Abs(nearestIndex - secNearestIndex) == 1)
        {
            nearestPoints.Add(items[nearestIndex]);
            nearestPoints.Add(items[secNearestIndex]);
        }
          

        //Debug.Log(a+"   "+b);
        //Debug.Log(nearestIndex + "    " + secNearestIndex);

        //for (int i = 0; i < items.Count; i++)
        //{
        //    if (Vector3.Distance(items[i].position, point) < distance &&
        //        Vector3.Distance(items[i].position, point) < distance1)
        //    {
        //        distance = Vector3.Distance(items[i].position, point);
        //        nearestIndex = i;
                
        //    }
        //    else if (Vector3.Distance(items[i].position, point) >= distance &&
        //             Vector3.Distance(items[i].position, point) < distance1)
        //    {
        //        distance1 = Vector3.Distance(items[i].position, point);
        //        secNearestIndex = i;
        //    }
       // }


        //if (Mathf.Abs(nearestIndex - secNearestIndex) == 1)
        //{
        //    nearestPoints.Add(items[nearestIndex]);
        //    nearestPoints.Add(items[secNearestIndex]);

        //    //Debug.Log("A: " + items[nearestIndex].GetChild(0).gameObject.GetComponent<AlgebraModel>().getValue() + "B: " +
        //    //    items[secNearestIndex].GetChild(0).gameObject.GetComponent<AlgebraModel>().getValue());

        //    Debug.Log(nearestIndex+" ---  "+secNearestIndex);


        //}


        return nearestPoints;
    }

   
}