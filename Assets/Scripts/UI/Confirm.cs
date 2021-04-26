using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("DestroyThis",1.5f);
    }

    public void DestroyThis()
    {
        Debug.Log("I AM DIED");
        Destroy(this.gameObject);
    }
}
