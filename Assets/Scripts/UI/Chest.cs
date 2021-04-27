using Data;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class Chest : MonoBehaviour
    {
        [SerializeField] private Transform chestTs;
        [SerializeField] private Transform viewPortTs;
        [FormerlySerializedAs("box")] [SerializeField] private GameObject boxPrefab;
        [SerializeField] private Text coinAmount;

        private int amount;
        //[SerializeField] private int co

        public void Start()
        {
            //对数据进行热更新，留出接口，方便将来从服务器读取数据
            StaticData.Instance.coinAmounts = 0;
            amount = 0;
            CreateBox();
        }

        private void Update()
        {
            if (amount != StaticData.Instance.coinAmounts)
            {
                amount = StaticData.Instance.coinAmounts;
                coinAmount.text = StaticData.Instance.coinAmounts + "K";
            }
            
        }

        public void CloseButtonOnClick() //销毁chest
        {
            Destroy(chestTs.gameObject);
        }

        private void CreateBox() //创建box
        {
            var box = Instantiate(boxPrefab, viewPortTs);
            box.name = "box";
            box.transform.localScale = Vector3.one;
            box.transform.localPosition = Vector3.zero;
        }
    }
}