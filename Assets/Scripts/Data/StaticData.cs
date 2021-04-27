using System.Runtime.CompilerServices;
using Base;

namespace Data
{
    public abstract class StaticData : Singleton<CoinDataClass>
    {
        //用于全局金币数量的调用
    }
}