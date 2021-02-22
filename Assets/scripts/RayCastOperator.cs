using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastOperator : MonoBehaviour
{
    private List<GameObject> islem;
    public Ray _ray;
    private RaycastHit _hit;


    private void Awake()
    {
        islem = new List<GameObject>();
       
    }

    private void Update()
    {
        foreach (GameObject op in islem)
        {
            if (op != null)
            {
                Debug.DrawRay(op.transform.position, (_hit.point - op.transform.position), Color.red);
                Ray ray = new Ray(op.transform.position, (_hit.point - op.transform.position));

                _ray = ray;
                
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        if (islem != null)
        {

            foreach (GameObject op in islem)
            {

                if (op != null)
                {
                    Gizmos.color = Color.red;

                    Gizmos.DrawWireSphere(_hit.point, 0.5f);
                }

            }
        }
    }

    public void Addoperator(GameObject op) {   
        
        islem.Add(op);
    }

    public Ray GetRay()
    {
        return this._ray;

    }

    public void setRayCastHit(RaycastHit hit)
    {
        this._hit = hit;
    }
    
    
}
