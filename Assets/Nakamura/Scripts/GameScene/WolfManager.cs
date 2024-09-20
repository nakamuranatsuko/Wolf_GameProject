using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class WolfManager : MonoBehaviour
{
    [SerializeField]
    private GameObject howToPlayCanvas;
    [SerializeField]
    private GameObject goToTitleCanvas;
    [SerializeField]
    private GameObject turnStartCanvas;
    [SerializeField]
    private GameObject rouletteCanvas;

    private float mouseAmount;

    private bool wolfFlg = false;

    [SerializeField]
    SpineAnimationController spineAnimationController;

    [SerializeField]
    private int wolfActiveMove = 7;
    [SerializeField]
    private int wolfWarningMove = 1;

    private enum wolfMotion
    {
        wolfIdle = 0,
        wolfWarning = 1,
        wolfActive = 2
    }

    void Update()
    {
        //�Q�[���ȊO�̉�ʂȂ牺�̏����ɍs���Ȃ�(�K�[�h��)
        if (howToPlayCanvas.activeSelf) return;
        if (goToTitleCanvas.activeSelf) return;
        if (rouletteCanvas.activeSelf) 
        {
            //�A�j���[�V�����Đ�
            spineAnimationController.WolfIdleAnimation();
            return;
        }
        if (turnStartCanvas.activeSelf) return;

        //�A�C�e�����h���b�O����ĂȂ��Ԃ͖���
        if (DragItem.ItemDragFlg == false) return;

        if(Input.GetMouseButton(0))
        {
            mouseAmount= new Vector2(Input.GetAxis("Mouse X")
                , Input.GetAxis("Mouse Y"))
                .magnitude * 10;

            Debug.Log(mouseAmount);

            if (wolfFlg && mouseAmount >= wolfActiveMove) WolfActive();
            if (wolfFlg && mouseAmount == 0)
            {
                //�A�j���[�V�����Đ�
                spineAnimationController.WolfIdleAnimation();
                wolfFlg = false;
            }

            if (wolfFlg) return;

            //�ړ��ʂ�����Ȃ�
            if (!wolfFlg && mouseAmount >= wolfWarningMove) wolfFlg = true;
        }
    }

    private void WolfActive()
    {
        //�A�j���[�V�����Đ�
        spineAnimationController.WolfActiveAnimation();
        TurnChangeManager.WolfFlg = true;
        Debug.Log("�T���N����");
        wolfFlg = false;
    }
}
