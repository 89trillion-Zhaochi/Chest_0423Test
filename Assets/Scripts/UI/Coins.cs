using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(DestroyThis),StaticData.Instance.coinAni);
    }

    public void DestroyThis()
    {
        Debug.Log("I AM DIED");
        Destroy(this.gameObject);
    }
}
