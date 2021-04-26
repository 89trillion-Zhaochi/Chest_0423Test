using UnityEngine;

namespace Data
{
    public class CoinDataClass
    {
        //金币数量相关的全局参数
        public Vector3 coinTrans;//金币UI的位置
        public int coinAmounts;//金币的数量
        public int addCount;//单次购买的金币数量
        
        //动画节奏相关的全局参数
        public float coinAniDelay; //金币动画的延迟移动时间
        public float coinAni;//金币动画的总时间
        public float coinAniMove;//金币动画移动的时间
        public float coinGap;//一组金币中间隔的时间

        public float confirmTime;//确认时间
    }
}