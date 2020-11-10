using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ElementContainerModel : MonoBehaviour
{
    public List<Transform> items;  // element container leveldataya bilgi vermesi lazimki her levelda kac item üretileccegi bilinsin 
    private float _distanceBetweenItems;    // su an public 10 diye ayarladm. // Array olsa daha iyi gibi sanki




    private void start()
    {
        
    }
    private void Update()
    {
        foreach(Transform i in items)
        {
            if(i != null)
            i.Translate(0, 0, 0.01f);
        }
    }

    public void AddElement(Transform element)
    {
        if (items == null)
            items = new List<Transform>();

        items.Add(element);
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
            if (Vector3.Distance(items[i].position, point) < nearestDistance && Vector3.Distance(items[i].position, point) < secNearestDistance)
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
        return nearestPoints;
    }
}