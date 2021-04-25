using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Transform chestTs;
    [SerializeField] private Transform viewPortTs;
    [SerializeField] private GameObject box;
    [SerializeField] private Transform coinUI;
    //[SerializeField] private int co

    public void Start()
    {
        StaticData.Instance.coinTrans = coinUI.localPosition;
        Debug.Log(StaticData.Instance.coinTrans+"????");
        CreateBox();
    }

    public void CloseButtonOnClick()//销毁chest
    {
        Destroy(chestTs.gameObject);
    }
    
    public void CreateBox()//创建box
    {
        var _box = Instantiate(box, viewPortTs);
        _box.name = "box";
        _box.transform.localScale = Vector3.one;
        _box.transform.localPosition = Vector3.zero;
    }
    
    
    
}
