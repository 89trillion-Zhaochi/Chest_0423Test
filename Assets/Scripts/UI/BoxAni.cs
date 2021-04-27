using UnityEngine;

namespace UI
{
    public class BoxAni : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int Isopen = Animator.StringToHash("isopen");
        private static readonly int Open = Animator.StringToHash("close2open");
        [SerializeField] private Box box;
        public void RecoverBox()
        {
            animator.SetBool(Isopen,false);
        }

        public void Close2Open()
        {
            animator.SetBool(Open,true);
        }

        public void CreatCoinAniCall()
        {
            box.CreatCoins();
            box.ChangeConfirm();
        }
    }
}
