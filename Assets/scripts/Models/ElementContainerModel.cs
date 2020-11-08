using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ElementContainerModel : MonoBehaviour
{
    public List<Transform> items;
    private float _distanceBetweenItems;


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