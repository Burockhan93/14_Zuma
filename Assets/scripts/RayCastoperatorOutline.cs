using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastoperatorOutline : MonoBehaviour
{
    List<Transform> _selection = new List<Transform>();
    public LayerMask layermask;
    public void Check(Ray ray)
    {
        this._selection.Clear();

        RaycastHit[] hits = Physics.SphereCastAll(ray.origin, 1.89f, ray.direction, Mathf.Infinity,layermask);

        //Debug.Log(ray.origin);

        foreach (var hit in hits)
        {

            if (hit.transform.CompareTag("number"))
            {
                if (!this._selection.Contains(hit.transform))
                {
                    this._selection.Add(hit.transform);
                }
                

            }
        }

    }
    public List<Transform> GetSelection()
    {
        return this._selection;
    }
}
