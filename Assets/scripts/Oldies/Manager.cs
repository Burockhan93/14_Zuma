using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Manager : MonoBehaviour
{
    sayi sayiInManager;
    public Transform[] paths;
    public ParticleSystem p;
    Collider m;

    private digits _prefab;
    private float _countdown;

    [Range(0.0f, 5.0f)] public float _speed;
    int ilkSayi;
    
    void Start()
    {
        p = GetComponent<ParticleSystem>();
        _speed = 0.1f;
        _countdown = 0;
        _prefab = FindObjectOfType<digits>();
        sayiInManager.myEvent.AddListener(dMove);
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _countdown -= Time.deltaTime;
        if (_countdown <= 0)
        {
            
            sayiInManager =_prefab.create();
            m= sayiInManager.GetComponent<Collider>();
            if (m != null) {
                m.isTrigger = false;
                Move(sayiInManager);              
            }
           _countdown = 2;
        }
        
    }

    void Move(sayi sayi)
    {

        Sequence mysequence = DOTween.Sequence();
        sayi.transform.position = paths[0].position;
        mysequence.Append(sayi.transform.DOMove(paths[1].position,6f)).Append(sayi.transform.DOMove(paths[2].position, 3f)).Append(sayi.transform.DOMove(paths[3].position, 6f));
        
        
    }

    void dMove()
    {
        Debug.Log("Event calisti");
        p.transform.position = sayiInManager.gameObject.transform.position;
        p.Play();

    }

   
}
