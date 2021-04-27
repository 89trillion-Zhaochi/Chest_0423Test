using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxAni : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int Isopen = Animator.StringToHash("isopen");
    private static readonly int Open = Animator.StringToHash("close2open");

    public void RecoverBox()
    {
        animator.SetBool(Isopen,false);
    }

    public void Close2Open()
    {
        animator.SetBool(Open,true);
    }
}
