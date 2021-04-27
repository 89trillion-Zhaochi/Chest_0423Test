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
        
        private int count;

        private void Start()
        {
            animatorBox.enabled = false;
        }

        
        //按下按钮之后
        public void PurchasedButtonOnClick()
        {
            //1.显示宝箱动画
            animatorBox.enabled = true;
            //2.显示加载文字
            confirmText.text = "正在打开宝箱..."; //打开宝箱文字显示
            Invoke(nameof(ChangeConfirm), StaticData.Instance.confirmTime);
            //3.计算实际生成的金币数和金币动画数
            if (StaticData.Instance.addCount <= 3)
            {
                count = StaticData.Instance.addCount * 5 - 1;
            }
            else
            {
                count = 14;
            }
            //4.调用金币动画，修改按钮显示金币数，修改金币总数
            Invoke(nameof(CreatCoins), StaticData.Instance.confirmTime);
            Invoke(nameof(ChangeButton),
                StaticData.Instance.coinAni + StaticData.Instance.confirmTime + count * StaticData.Instance.coinGap);
        }
        
        //修改按钮文字
        public void ChangeButton()
        {
            StaticData.AmountAdd();
            StaticData.SelfAdd();
            purchasedButtonText.text = "购买 " + StaticData.Instance.addCount.ToString() + "K金币";
        }
        //调用创建金币的具体函数
        public void CreatCoins() 
        {
            InvokeRepeating(nameof(PlayCoinsAni), 0, StaticData.Instance.coinGap);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        // 创建具体数目的金币动画实体
        public void PlayCoinsAni()
        {
            var coins = Instantiate(coinsPrefab, coinsParents);
            coins.name = "coin";
            coins.transform.localScale = Vector3.one * 50;
            coins.transform.localPosition = confirmTs.localPosition +
                                            new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
            //利用随机数对金币生成的位置做一个小的随机生成
            //new Vector3(0,350,90);//应该是最佳位置
            coins.transform.DOLocalMove(coinMove, StaticData.Instance.coinAniMove)
                .SetDelay(StaticData.Instance.coinAniDelay);
            if (--count < 0)
            {
                CancelInvoke(nameof(PlayCoinsAni));
            }
        }
        
        public void ChangeConfirm()
        {
            confirmText.text = "";
        }
    }
}