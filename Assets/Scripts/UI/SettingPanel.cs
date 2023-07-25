using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator= GetComponent<Animator>();
    }
    public void OnBack()
    {
        animator.SetTrigger(Constant.slideUp);
        
    }
}
