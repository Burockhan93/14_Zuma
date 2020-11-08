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
            
            sayiInPlayer = _prefab.create();
            sayiInPlayer.tag = "mermi";
            if (sayiInPlayer.tag=="mermi")
            Movesayi(sayiInPlayer, hit);

        }   

    }

    void Movesayi(sayi sayi, RaycastHit hit)
    {
        
        sayiInPlayer.transform.position = transform.position;
        sayiInPlayer.transform.DOMove(hit.point, 2f).OnComplete(() => Destroy(sayiInPlayer.gameObject));
        
    }






}
