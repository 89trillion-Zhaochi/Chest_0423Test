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
        [SerializeField] private Transform coinUI;

        [SerializeField] private Text coinAmount;
        //[SerializeField] private int co

        public void Start()
        {
            //对数据进行热更新，留出接口，方便将来从服务器读取数据
            StaticData.Instance.coinTrans = coinUI.localPosition;
            StaticData.Instance.addCount = 1;
            StaticData.Instance.coinAmounts = 0;
            StaticData.Instance.coinAniDelay = 1.3f;
            StaticData.Instance.coinAniMove = 0.7f;
            StaticData.Instance.coinAni = StaticData.Instance.coinAniDelay + StaticData.Instance.coinAniMove;
            StaticData.Instance.coinGap = 0.1f;
            StaticData.Instance.confirmTime = 1.3f;
        
        
            CreateBox();
        }

        private void Update()
        {
            coinAmount.text = StaticData.Instance.coinAmounts.ToString() + "K";
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