using Base;

namespace Data
{
    public class StaticData : Singleton<CoinDataClass>
    {
        
        public static void SelfAdd() //可购买的金币数量自增长
        {
            Instance.addCount ++;
        }

        public static void AmountAdd()//总量的增加
        {
            Instance.coinAmounts += Instance.addCount;
        }
    }
}