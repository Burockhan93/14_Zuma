using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitModel : MonoBehaviour,IHoldable
{
    public int Value
    {
        get => Value;
        set => Value = value;
    }
    public GameObject _holdable { get; set; }

    public void Hit(Collider other)
    {
        
    }
}
