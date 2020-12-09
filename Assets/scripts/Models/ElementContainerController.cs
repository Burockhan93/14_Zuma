using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.UIElements;
using UnityEngine;

public class ElementContainerController : MonoBehaviour
{
    public List<Transform>
        items; // element container leveldataya bilgi vermesi lazimki her levelda kac item üretileccegi bilinsin 

    private float _distanceBetweenItems; // su an public 10 diye ayarladm. // Array olsa daha iyi gibi sanki
    

    [SerializeField] private LevelManager _levelManager;
    private int createdItemCount = 0;

    private int IndextoReturn; // buraya da bakilacak listede yok olan iki elemannin yerine yeni prefab eklenecegi zaman caöiisiyor.

    private void Update()
    {
        /*foreach(Transform i in items)
        {
            if(i != null)
            i.Translate(0, 0, 0.01f);
        }*/
    }

    private void Awake()
    {
        LevelManager.onLevelEnd.AddListener(() => createdItemCount = 0);
    }

    public void AddElement(Transform element, AlgebraModel model)
    {
        if (items == null)
            items = new List<Transform>();

        items.Add(element);
        Debug.Log(model.Value);
        AddAlgebra(model);
    }

    public void AddAlgebra(AlgebraModel model)
    {
        var j = items.Count;
        Transform i = items[j - 1];
        GameObject addedModel;
        addedModel = Instantiate(model._holdable, items[j - 1].transform.position, Quaternion.identity);
               
        addedModel.AddComponent<AlgebraModel>();
        addedModel.GetComponent<AlgebraModel>().setValue(model.getValue()); // cok karmasik düzelmesi gerek
        addedModel.transform.parent = i.transform;

        var path = _levelManager.GetCurrentPath();
        var levelTime = _levelManager.GetLevelTime();
        var itemNumber = _levelManager.GetLevelDigitNumber();
        FollowPath(path, i, levelTime, itemNumber);
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
                .OnComplete(() => LevelManager.onLevelEnd.Invoke());
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

    public List<Transform> GetNearestTwoTransforms(Vector3 point)
    {
        List<Transform> nearestPoints = new List<Transform>();
        int counter = 0;

        float nearestDistance = Mathf.Infinity;
        float secNearestDistance = Mathf.Infinity;

        int nearestIndex = 0;
        int secNearestIndex = 0;

        for (int i = 0; i < items.Count; i++)
        {
            if (Vector3.Distance(items[i].position, point) < nearestDistance &&
                Vector3.Distance(items[i].position, point) < secNearestDistance)
            {
                nearestDistance = Vector3.Distance(items[i].position, point);
                nearestIndex = i;
            }
            else if (Vector3.Distance(items[i].position, point) >= nearestDistance &&
                     Vector3.Distance(items[i].position, point) < secNearestDistance)
            {
                secNearestDistance = Vector3.Distance(items[i].position, point);
                secNearestIndex = i;
            }
        }

        nearestPoints.Add(items[nearestIndex]);
        nearestPoints.Add(items[secNearestIndex]);
        

        if(nearestIndex < secNearestIndex)
        {
            IndextoReturn = nearestIndex;
        }
        else
        {
            IndextoReturn = secNearestIndex;
        }


        return nearestPoints;
    }

    public int getIndextoReturn()
    {
        return IndextoReturn;
    }
}