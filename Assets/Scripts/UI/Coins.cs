using Data;
using UnityEngine;

namespace UI
{
    public class Coins : MonoBehaviour
    {
        private void Start()
        {
            Invoke(nameof(DestroyThis),StaticData.Instance.coinAni);
        }

        public void DestroyThis()
        {
            Destroy(this.gameObject);
        }
    }
}
