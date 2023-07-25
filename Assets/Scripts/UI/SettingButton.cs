using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;

    Animator animator;

    private void Awake()
    {
        animator = settingPanel.GetComponent<Animator>();
    }

    public void OnClick()
    {
        animator.SetTrigger(Constant.slideDown);
    }
}
