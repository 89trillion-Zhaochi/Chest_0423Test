using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shine : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem.Play();
    }
}
