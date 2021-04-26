using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private Transform rootTs;

        [FormerlySerializedAs("chest")] [SerializeField] private GameObject chestPrefab;
        //点击Root按钮事件
        public void OpenButtonOnClick()
        {
            var chest = Instantiate(chestPrefab, rootTs);
            chest.name = "Chest";
            chest.transform.localScale = Vector3.one;
            chest.transform.localPosition = Vector3.zero;
            Debug.Log("OpenButtonOnClick");
        }
    }
}
