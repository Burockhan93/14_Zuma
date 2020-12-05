using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;
using DG.Tweening;
using UnityEditor;
using UnityStandardAssets.Utility;

public class PlayerController : MonoBehaviour
{
    private digits _prefab;
    private sayi sayiInPlayer;
    Collider m_ObjectCollider;

    public GameObject algebra;
    private AlgebraModel _algebra;
    
    void Start()
    {
        _prefab = FindObjectOfType<digits>();
        
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
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left),out hit, Mathf.Infinity,1<<8))
        {
           
            _algebra = new AlgebraModel(2, Instantiate(algebra, transform.position, Quaternion.identity));
            
            //_algebra = Instantiate(_algebra, transform.position, Quaternion.identity);
            //_algebra.gameObject.AddComponent<AlgebraModel>();
            //Debug.Log(_algebra.Value);
            Movesayi(_algebra, hit);

        }   

    }

    void Movesayi(AlgebraModel _algebra, RaycastHit hit)
    {
        
        _algebra.transform.position = transform.position;
        while (Vector3.Distance(_algebra.transform.position,hit.point) < 0.5f)
        {
            _algebra.transform.position = Vector3.MoveTowards(_algebra._holdable.transform.position, hit.point, 0.5f);
        }
        //_algebra._holdable.transform.DOMove(hit.point, 2f).OnComplete(() => Destroy(sayiInPlayer.gameObject));
        
    }






}
