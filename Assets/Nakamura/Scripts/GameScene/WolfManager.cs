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
        //ゲーム以外の画面なら下の処理に行かない(ガード節)
        if (howToPlayCanvas.activeSelf) return;
        if (goToTitleCanvas.activeSelf) return;
        if (rouletteCanvas.activeSelf) 
        {
            //アニメーション再生
            spineAnimationController.WolfIdleAnimation();
            return;
        }
        if (turnStartCanvas.activeSelf) return;

        //アイテムがドラッグされてない間は無効
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
                //アニメーション再生
                spineAnimationController.WolfIdleAnimation();
                wolfFlg = false;
            }

            if (wolfFlg) return;

            //移動量があるなら
            if (!wolfFlg && mouseAmount >= wolfWarningMove) wolfFlg = true;
        }
    }

    private void WolfActive()
    {
        //アニメーション再生
        spineAnimationController.WolfActiveAnimation();
        TurnChangeManager.WolfFlg = true;
        Debug.Log("狼が起きた");
        wolfFlg = false;
    }
}
