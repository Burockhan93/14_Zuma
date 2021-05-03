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

        RaycastHit[] hits = Physics.SphereCastAll(ray.origin, 1f, ray.direction, Mathf.Infinity,layermask);

        RaycastHit hit1;

        Physics.Raycast(ray, out hit1, Mathf.Infinity, 1 << 8);

        foreach (var hit in hits)
        {
            if (hit.transform.CompareTag("number"))
            {

                if (!this._selection.Contains(hit.transform) && Vector3.Distance(hit.transform.position,hit1.point)<1f) { 
                    
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
