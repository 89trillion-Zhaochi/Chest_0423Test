using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Transform rootTs;

    [SerializeField] private GameObject chest;
    //点击Root按钮事件
    public void OpenButtonOnClick()
    {
        var _chest = Instantiate(chest, rootTs);
        _chest.name = "Chest";
        _chest.transform.localScale = Vector3.one;
        _chest.transform.localPosition = Vector3.zero;
        Debug.Log("OpenButtonOnClick");
    }
}
