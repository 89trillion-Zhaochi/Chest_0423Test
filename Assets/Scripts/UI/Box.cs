using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.Collections;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class Box : MonoBehaviour
{
    public bool isclose = true;

    public int isplay = 0; //正在播放的金币动画数量
    [SerializeField] private GameObject coinsPrefab;
    [SerializeField] private Transform coinsParents;
    [SerializeField] private Animator animatorBox;
    [SerializeField] private Animation animationBox;
    [SerializeField] private ParticleSystem particleSystemShine;
    [SerializeField] private GameObject confirmPrefab;
    [SerializeField] private GameObject shinePrefab;
    [SerializeField] private Vector3 shineScale;
    [SerializeField] private Vector3 shinePos;
    [SerializeField] private Transform buttonts;
    [SerializeField] private Vector3 coinmove;
    [SerializeField] private Text confirmText;
    [SerializeField] private AnimationCurve selfSetTweenLine;
    [SerializeField] private Text purchasedButtonText; 
    private int count = 0;

    private void Start()
    {
        animatorBox.enabled = false;
        
    }

    public void PurchasedButtonOnClick()
    {
        var confirmPanel = Instantiate(confirmPrefab);
        confirmPanel.transform.localPosition = Vector3.zero;
        animatorBox.enabled = true;
        animationBox.Play();
        confirmText.text = "正在打开宝箱..."; //打开宝箱文字显示
        Invoke(nameof(ChangeConfirm), StaticData.Instance.confimTime);
        if(StaticData.Instance.addCount <= 3)
        {
            count = StaticData.Instance.addCount * 5-1;
        }
        else
        {
            count = 14;
        }
        Invoke(nameof(CreatCoins),StaticData.Instance.confimTime);
        Invoke(nameof(ChangeButton),
            StaticData.Instance.coinAni+StaticData.Instance.confimTime+count*StaticData.Instance.coinGap);
    }

    public void ChangeButton()
    {
        StaticData.AmountAdd();
        StaticData.SelfAdd();
        purchasedButtonText.text = "购买 "+StaticData.Instance.addCount.ToString() + "K金币";
    }
    public void CreatCoins()//每次创建5个金币
    {
        InvokeRepeating("PlayCoinsAni", 0, StaticData.Instance.coinGap);
    }
    // ReSharper disable Unity.PerformanceAnalysis
    public void PlayCoinsAni()
    {
        
        var coins = Instantiate(coinsPrefab, coinsParents);
        coins.name = "coin";
        coins.transform.localScale = new Vector3(50, 50, 50);
        var position = buttonts.position;
        coins.transform.localPosition = position;
        Debug.Log(position.ToString());
        coins.transform.DOLocalMove(coinmove, StaticData.Instance.coinAniMove).SetDelay(StaticData.Instance.coinAniDelay);
        if (--count< 0)
        {
            CancelInvoke(nameof(PlayCoinsAni));
        }
    }

    public void ChangeConfirm()
    {
        confirmText.text = "";
    }
}