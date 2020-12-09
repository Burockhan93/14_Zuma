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
    private digits _prefab;
    private sayi sayiInPlayer;
    Collider m_ObjectCollider;

    public GameObject algebra;
    private AlgebraModel _algebra;

    void Start()
    {
        _prefab = FindObjectOfType<digits>();
        onPlayerHit.AddListener((vec)=> Debug.Log(vec.x +","+vec.y +","+vec.z +": Hitted"));
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
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity,
            1 << 8))
        {
            _algebra = Instantiate(algebra, transform.position, Quaternion.identity).GetComponent<AlgebraModel>();
            _algebra.Value = 2;
            //_algebra = Instantiate(_algebra, transform.position, Quaternion.identity);
            //_algebra.gameObject.AddComponent<AlgebraModel>();
            //Debug.Log(_algebra.Value);
            Movesayi(_algebra, hit);
        }
    }

    void Movesayi(AlgebraModel _algebra, RaycastHit hit)
    {
        _algebra.transform.position = transform.position;

        _algebra.transform.DOMove(hit.point, 1f).OnComplete(()=> onPlayerHit.Invoke(hit.point));

        //_algebra._holdable.transform.DOMove(hit.point, 2f).OnComplete(() => Destroy(sayiInPlayer.gameObject));
    }
}

[System.Serializable]
public class HitEvent : UnityEvent<Vector3>
{
}