using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    public ParticleSystem[] particles;
    public Particles[] _particles;
 
    private ParticleSystem _p;

    public void Play(Vector3 vec)
    {
        Debug.Log("play");
        switch (CalculatorManager.islem)
        {
            case AlgebraOperator.operations.ADD:

                _p = particles[0];
                Instantiate(_p,vec,Quaternion.Euler(0,90,0)).Play();
                Destroy(_p, 0.5f);
                
                break;

            case AlgebraOperator.operations.DIVIDE:

                _p = particles[1];
                Instantiate(_p, vec, Quaternion.Euler(0, 90, 0)).Play();
                Destroy(_p, 0.5f);

                break;

            case AlgebraOperator.operations.MULTIPLY:

                _p = particles[2];
                Instantiate(_p, vec, Quaternion.Euler(0, 90, 0)).Play();
                Destroy(_p, 0.5f);

                break;

            case AlgebraOperator.operations.SUBTRACT:

                _p = particles[3];
                Instantiate(_p, vec, Quaternion.Euler(0, 90, 0)).Play();
                Destroy(_p, 0.5f);

                break;

            default: Debug.Log("Default"); break;
        }
    }
}
