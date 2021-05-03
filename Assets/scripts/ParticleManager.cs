using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParticleManager : MonoBehaviour
{

    public ParticleSystem[] particles;

    private ParticleSystem _p;


    public void Play(Vector3 vec)
    {
        
        switch (CalculatorManager.islem)
        {
            case AlgebraOperator.operations.ADD:

                _p = Instantiate(particles[0],vec, Quaternion.Euler(0, 90, 0));              
                _p.Play();               
                Destroy(_p.gameObject, 0.5f);
                break;

            case AlgebraOperator.operations.DIVIDE:

                _p = Instantiate(particles[3], vec, Quaternion.Euler(0, 90, 0));
                _p.Play();
                Destroy(_p.gameObject, 0.5f);
                break; ;

            case AlgebraOperator.operations.MULTIPLY:

                _p = Instantiate(particles[2], vec, Quaternion.Euler(0, 90, 0));
                _p.Play();
                Destroy(_p.gameObject, 0.5f);
                break;

            case AlgebraOperator.operations.SUBTRACT:

                _p = Instantiate(particles[1], vec, Quaternion.Euler(0, 90, 0));
                _p.Play();
                Destroy(_p.gameObject, 0.5f);
                break;

            default: Debug.Log("Default"); break;
        }
    }
}
