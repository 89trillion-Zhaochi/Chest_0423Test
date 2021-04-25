using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Box : MonoBehaviour
{
    public bool isclose = true;

    public int isplay = 0; //正在播放的金币动画数量

    //[SerializeField] private Transform coins;
    [SerializeField] private GameObject coinsPrefab;
    [SerializeField] private Transform coinsParents;
    [SerializeField] private Animator anim;

    [SerializeField] private Transform buttonts;

    // [SerializeField] private Transform coinendTS;
    //[SerializeField] private Transform coinsTS;//test

    [SerializeField] private Vector3 coinmove;
    private int count = 0;
    private void Start()
    {
        anim.Play("box_close_1");
    }
    public void PurchasedButtonOnClick()
    {
        //播放开箱动画，播放金币动画，修改金币数量
        isclose = false;
        if (isplay < 3)
        {
            isplay++;
            InvokeRepeating("PlayCoinsAni",0,0.1f);
            anim.Play("box_open_2");
            count = 0;
        }

        Debug.Log("ispurchased");
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void PlayCoinsAni()
    {
        
        count++;
        var coins = Instantiate(coinsPrefab,coinsParents);
        coins.name = "coin";
        coins.transform.localScale = new Vector3(0.24f, 0.24f, 0.24f);
        //StartCoroutine(WaitAndPrint(1f)); 
        coins.transform.localPosition = buttonts.position;
        coins.transform.DOLocalMove(coinmove, 3);
       
        // yield return new WaitForSecondsRealtime(0.5f);
        //coins.transform.DOMove(StaticData.Instance.coinTrans, 1);
        //播放完毕后，会让isplay的数量减少
        if (count > 4)
        {
            count = 0;
            CancelInvoke("PlayCoinsAni");
        }
    }
}