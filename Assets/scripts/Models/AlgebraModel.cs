using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgebraModel : MonoBehaviour
{

   [SerializeField] private int value;

    public int getValue()
    {
        return value;
    }

    public void setValue(int val)
    {
        value = val;
       
    }
}