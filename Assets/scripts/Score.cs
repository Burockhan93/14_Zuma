using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMesh text;
    [SerializeField] TextMesh level;


    public void Add(int val)
    {
        text.text = ""+val; 
    }

    public void Level(int lvl)
    {
        level.text = "Level " + lvl;
    }
}
