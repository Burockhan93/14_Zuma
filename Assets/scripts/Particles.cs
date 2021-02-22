using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Particles
{

    public string name;
    public ParticleSystem particle;
    public AlgebraOperator algebraOperator;

    
    public float volume;
    
    public float pitch;

    

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
