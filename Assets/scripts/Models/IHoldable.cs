
using UnityEngine;

public interface IHoldable
{
    int Value { get; set; }
    GameObject _holdable { get; set; }

    //List<GameObject> digits { get; set; }

    
    void Hit(Collider other);
}