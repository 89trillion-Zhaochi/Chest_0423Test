using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [SerializeField] private Transform chestTs;
    [SerializeField] private Transform viewPortTs;
    [SerializeField] private GameObject box;
    [SerializeField] private Transform coinUI;

    [SerializeField] private Text coinAmount;
    //[SerializeField] private int co

    public void Start()
    {
        //对数据进行更新
        StaticData.Instance.coinTrans = coinUI.localPosition;
        StaticData.Instance.addCount = 1;
        StaticData.Instance.coinAmounts = 0;
        StaticData.Instance.coinAniDelay = 1.3f;
        StaticData.Instance.coinAniMove = 0.7f;
        StaticData.Instance.coinAni = StaticData.Instance.coinAniDelay + StaticData.Instance.coinAniMove;
        StaticData.Instance.coinGap = 0.1f;
        StaticData.Instance.confimTime = 1.3f;
        CreateBox();
    }

    private void Update()
    {
        coinAmount.text = StaticData.Instance.coinAmounts.ToString() + "K";
    }

    public void CloseButtonOnClick() //销毁chest
    {
        Destroy(chestTs.gameObject);
    }

    public void CreateBox() //创建box
    {
        var _box = Instantiate(box, viewPortTs);
        _box.name = "box";
        _box.transform.localScale = Vector3.one;
        _box.transform.localPosition = Vector3.zero;
    }
}