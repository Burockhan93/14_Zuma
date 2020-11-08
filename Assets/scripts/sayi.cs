using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class sayi : MonoBehaviour
{
    public int value;
    public UnityEvent myEvent;
    public ParticleSystem p;


    void Start()
    {
        p = GetComponentInChildren<ParticleSystem>();
    }
    void Update()
    {

        Vector3 forward = transform.TransformDirection(Vector3.left) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<sayi>() != null && other.CompareTag("mermi"))
        {
            p.Play();
            myEvent.Invoke();

        }

    }

}
