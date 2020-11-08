using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PathData", order = 2)]
public class PathData : ScriptableObject
{
    public string ıds;
    public List<Vector3> paths;
}