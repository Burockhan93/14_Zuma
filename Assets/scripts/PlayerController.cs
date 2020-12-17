using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;
using DG.Tweening;
using UnityEditor;
using UnityEngine.Events;
using UnityStandardAssets.Utility;

public class PlayerController : MonoBehaviour
{
    public static HitEvent onPlayerHit = new HitEvent();
    
    public AlgebraOperator algebraOperator;

    
    void Start()
    {
        //onPlayerHit.AddListener((vec)=> Debug.Log(vec.x +","+vec.y +","+vec.z +": Hitted"));
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.left) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject _algebraOperator;
        int i = Random.Range(0, 4);


        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity,
            1 << 8))
        {
            //_algebra = Instantiate(algebra, transform.position, Quaternion.identity).GetComponent<AlgebraModel>();
            //_algebra.Value = 2;

            _algebraOperator = Instantiate(algebraOperator._operators[i], transform.position, Quaternion.identity);

            MoveIslem(_algebraOperator, hit);
        }
    }

    void MoveIslem(GameObject algebraOperator, RaycastHit hit)
    {

        algebraOperator.transform.position = transform.position;

        algebraOperator.transform.DOMove(hit.point, 0.5f).OnComplete(()=>MoveIslemOnComplete(hit.point,algebraOperator));
        
        //_algebra._holdable.transform.DOMove(hit.point, 2f).OnComplete(() => Destroy(sayiInPlayer.gameObject));
    }

    void MoveIslemOnComplete(Vector3 vec, GameObject algebraOperator)
    {

        CalculatorManager.islem = algebraOperator.GetComponent<AlgebraOperator>()._Operator;
        onPlayerHit.Invoke(vec);

    }


}

[System.Serializable]
public class HitEvent : UnityEvent<Vector3>
{
}