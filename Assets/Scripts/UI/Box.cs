using Data;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
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

        public void PurchasedButtonOnClick()
        {
            animatorBox.enabled = true;
            confirmText.text = "正在打开宝箱..."; //打开宝箱文字显示
            Invoke(nameof(ChangeConfirm), StaticData.Instance.confirmTime);
            if (StaticData.Instance.addCount <= 3)
            {
                count = StaticData.Instance.addCount * 5 - 1;
            }
            else
            {
                count = 14;
            }

            Invoke(nameof(CreatCoins), StaticData.Instance.confirmTime);
            Invoke(nameof(ChangeButton),
                StaticData.Instance.coinAni + StaticData.Instance.confirmTime + count * StaticData.Instance.coinGap);
        }

        public void ChangeButton()
        {
            StaticData.AmountAdd();
            StaticData.SelfAdd();
            purchasedButtonText.text = "购买 " + StaticData.Instance.addCount.ToString() + "K金币";
        }

        public void CreatCoins() //每次创建5个金币
        {
            InvokeRepeating(nameof(PlayCoinsAni), 0, StaticData.Instance.coinGap);
        }

        // ReSharper disable Unity.PerformanceAnalysis
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