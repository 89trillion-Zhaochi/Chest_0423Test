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
        [SerializeField] private Transform confirmTs;
        [SerializeField] private Animator animatorBox;
        [SerializeField] private Vector3 coinMove;
        [SerializeField] private Text confirmText;
        [SerializeField] private Text purchasedButtonText;

        //动画节奏相关的全局参数
        [SerializeField] private float coinAniDelay = 1.3f; //金币动画的延迟移动时间
        [SerializeField] private float coinAniMove = 0.7f; //金币动画移动的时间
        [SerializeField] private float coinGap = 0.1f; //一组金币中间隔的时间

        [SerializeField] private int addCount = 1;
        private int count;
        private static readonly int Isopen = Animator.StringToHash("isopen");
        private static readonly int Coinsallok = Animator.StringToHash("coinsallok");


        //按下按钮之后
        public void PurchasedButtonOnClick()
        {
            //1.播放宝箱动画
            animatorBox.SetBool(Isopen, true);
            animatorBox.SetBool(Coinsallok, false);
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

        //修改按钮文字 在箱子动画播放关键帧中调用
        private void ChangeButton()
        {
            float timer = 0;
            //DOTwwen.To()中参数：前两个参数是固定写法，第三个是到达的最终值，第四个是渐变过程所用的时间
            DOTween.To(() => timer, x => timer = x, 1, coinAniDelay + coinAniMove)
                .OnStepComplete(() => { StaticData.Instance.coinAmounts += addCount; });
            addCount++; //修改按钮上的数字
            purchasedButtonText.text = "购买 " + addCount.ToString() + "K金币";

            animatorBox.SetBool(Coinsallok, true);
        }


        //调用创建金币的具体函数
        public void CreatCoins()
        {
            Sequence seq = DOTween.Sequence();
            seq.AppendCallback(PlayCoinsAni).SetDelay(coinGap).SetLoops(count);
            seq.OnComplete((ChangeButton)); //所有的金币生成完再修改按钮
        }

        // ReSharper disable Unity.PerformanceAnalysis
        // 创建具体数目的金币动画实体
        private void PlayCoinsAni()
        {
            var coins = Instantiate(coinsPrefab, coinsParents);
            coins.transform.localScale = Vector3.one * 50;
            coins.transform.localPosition = confirmTs.localPosition +
                                            new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
            //利用随机数对金币生成的位置做一个小的随机生成

            //new Vector3(0,350,90);//应该是最佳位置
            Tweener tweener = coins.transform.DOLocalMove(coinMove, coinAniMove)
                .SetDelay(coinAniDelay);
            tweener.OnComplete(() => Destroy(coins)); //动画播放完后自销毁
        }

        public void ChangeConfirm()
        {
            confirmText.text = "";
        }
    }
}