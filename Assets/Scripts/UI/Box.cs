using Data;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Box : MonoBehaviour
    {
        [SerializeField] private GameObject coinsPrefab;
        [SerializeField] private Transform coinsParents;
        [SerializeField] private Animator animatorBox;
        [SerializeField] private Vector3 coinMove;
        [SerializeField] private Text confirmText;
        [SerializeField] private Text purchasedButtonText;
        [SerializeField] private Transform confirmTs;

        //动画节奏相关的全局参数
        [SerializeField] private float coinAniDelay = 1.3f; //金币动画的延迟移动时间
        [SerializeField] private float coinAniMove = 0.7f; //金币动画移动的时间
        [SerializeField] private float coinGap = 0.1f; //一组金币中间隔的时间
        [SerializeField] private int addCount = 1;
        private int count;
        private static readonly int Isopen = Animator.StringToHash("isopen");


        //按下按钮之后
        public void PurchasedButtonOnClick()
        {
            //1.播放宝箱动画
            animatorBox.SetBool(Isopen, true);
            //2.显示加载文字
            confirmText.text = "正在打开宝箱..."; //打开宝箱文字显示
            //3.计算实际生成的金币数
            if (addCount <= 3)
            {
                count = addCount * 5 - 1;
            }
            else
            {
                count = 14;
            }
        }

        //调用创建金币的具体函数
        public void CreatCoins()
        {
            Sequence seq =DOTween.Sequence();
            for (int i = 0; i < count; i++)
            {
                var coins = Instantiate(coinsPrefab, coinsParents);
                coins.SetActive(false);
                seq.InsertCallback(coinGap * i,() =>
                {
                    coins.SetActive(true);
                });
                seq.Insert(coinGap*i,coins.transform.DOScale(Vector3.one * 50, 0));
                seq.Insert(coinGap*i,coins.transform.DOLocalMove(confirmTs.localPosition +
                                                                 new Vector3(Random.Range(-10.0f, 10.0f),
                                                                     Random.Range(-10.0f, 10.0f), 0), 0));
                seq.Insert(coinGap*i,coins.transform.DOLocalMove(coinMove, coinAniMove).SetDelay(coinAniDelay)
                    .OnComplete(() => Destroy(coins)));
            }
            seq.AppendCallback(() =>
            {
                StaticData.Instance.coinAmounts += addCount;
                addCount++; //修改按钮上的数字
                Debug.Log("2");
                purchasedButtonText.text = "购买 " + addCount + "K金币";
            });
        }

        public void ChangeConfirm()
        {
            confirmText.text = "";
        }
    }
}