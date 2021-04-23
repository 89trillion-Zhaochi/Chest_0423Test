using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Transform chestTs;

    public void CloseButtonOnClick()//销毁chest
    {
        Destroy(chestTs.gameObject);
    }
}
