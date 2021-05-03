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
    [SerializeField] private Score _score;
    private int textNumber;

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
        FollowPath(items[j - 1]);
    }

   

    private void FollowPath(Transform elementCont)
    {
        var levelTime = _levelManager.GetLevelTime();
        var path = _levelManager.GetCurrentPath();

        elementCont.DOPath(path.paths.ToArray(), levelTime).SetEase(Ease.Linear).OnComplete(() =>
         {
             createdItemCount++;
             var itemNumber = _levelManager.GetLevelDigitNumber();
             var temp = itemNumber == createdItemCount;

             if (elementCont.childCount > 0) 
             {
                 textNumber += elementCont.GetChild(0).GetComponent<AlgebraModel>().getValue();
                 _score.Add(textNumber);
             }

             if (temp) LevelManager.onLevelEnd.Invoke();

         });

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

        for (int i=0; i < items.Count; i++)
        {
            liste.Add(i, Vector3.Distance(items[i].position, point));
            
        }

        float a = 2;
        float b = 2;

        foreach (KeyValuePair<int,float> mallik in liste)
        {
            if (mallik.Value < a)
            {
                a = mallik.Value;
                nearestIndex = mallik.Key;
            }
            
        }

        liste[nearestIndex] = Mathf.Infinity; // bunu aldik zaten geri donecek listeye simdi tekrar almamak icin infinity yapioz degeri

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
          
        return nearestPoints;
    }

   
}