using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgebraModel : MonoBehaviour, IHoldable
{

    public int Value { get; set; }
    //{
    //    get => Value;
    //    set => Value = value;
    //}

    public GameObject _holdable {get;set;}

    public AlgebraModel (int value, GameObject holdable)
    {
        Value = value;

        _holdable = holdable;
    }

    
    //public List<GameObject> digits  // IHoldable da liste olusturup ordan teket teker algebraya isaretleri alacatm olmadi .
    //{
    //    get; set;
    //}

    private void OnTriggerEnter(Collider other)
    {
        Hit(other);
        //Calculate(other);
    }

    public void Hit(Collider other)
    {
        if (other.GetComponent<AlgebraModel>() != null)
        {
            Debug.Log("algebramodel var");
        }
    }

    public void Calculate(Collider other)
    {
        Debug.Log(other.GetComponent<AlgebraModel>().Value);
    }
}