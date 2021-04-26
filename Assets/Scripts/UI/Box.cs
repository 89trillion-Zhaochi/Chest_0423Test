using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Serialization;

public class Box : MonoBehaviour
{
    public bool isclose = true;

    public int isplay = 0; //正在播放的金币动画数量

    //[SerializeField] private Transform coins;
    [SerializeField] private GameObject coinsPrefab;
    [SerializeField] private Transform coinsParents;
    [SerializeField] private Animator animatorBox;

    [SerializeField] private Animation animationBox;
    // [SerializeField] private Animator animatorShine;
    // [SerializeField] private Animation animationShine;
    [SerializeField] private ParticleSystem particleSystemShine;
    [SerializeField] private GameObject confirmPrefab;
    [SerializeField] private GameObject shinePrefab;
    [SerializeField] private Vector3 shineScale;
    [SerializeField] private Vector3 shinePos;
    [SerializeField] private Transform buttonts;

    // [SerializeField] private Transform coinendTS;
    //[SerializeField] private Transform coinsTS;//test

    [SerializeField] private Vector3 coinmove;
    private int count = 0;
    private void Start()
    {
        animatorBox.enabled = false;
    }
    public void PurchasedButtonOnClick()
    {
        //弹出确认弹窗，播放动画

        var confirmPanel = Instantiate(confirmPrefab,coinsParents);
        confirmPanel.transform.localPosition = new Vector3(30, 400, 0);  
        animatorBox.enabled = true;
        animationBox.Play();
        // animationBox.PlayQueued("box_close_1", QueueMode.CompleteOthers);
        // animationBox.PlayQueued("box_open_2", QueueMode.CompleteOthers);
        var shine = Instantiate(shinePrefab, coinsParents);
        shine.name = "shine";
        shine.transform.position = shinePos;
        shine.transform.localScale = shineScale;
        isclose = false;
        if (isplay < 3)
        {
            isplay++;
            InvokeRepeating("PlayCoinsAni",0,0.1f);
            // anim.enabled = true;
            // anim.Play("box_open_2");
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
        coins.transform.localScale = new Vector3(30, 30,30);
        coins.transform.localPosition = buttonts.position;
        coins.transform.DOLocalMove(coinmove, 3);
        //播放完毕后，会让isplay的数量减少
        if (count > 4)
        {
            count = 0;
            CancelInvoke("PlayCoinsAni");
        }
    }
}