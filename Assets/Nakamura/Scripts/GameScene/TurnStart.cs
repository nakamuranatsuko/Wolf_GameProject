using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System;

public class TurnStart : MonoBehaviour
{
    [SerializeField]
    private GameObject turnObj;
    [SerializeField]
    private GameObject turnPanel;

    [SerializeField]
    private GameObject rouletteCanvas;

    public async UniTask TurnChange()
    {
        //表示
        turnObj.gameObject.SetActive(true);

        //少し止まる
        await UniTask.Delay(TimeSpan.FromSeconds(3));

        //初期位置へ
        turnPanel.transform.position = new Vector3(2000, 540, 0);
        //左から真ん中へ
        turnPanel.transform.DOMove(new Vector3(960, 540, 0), 1f);
        //少し止まる
        await UniTask.Delay(TimeSpan.FromSeconds(2));
        //真ん中から右へ
        turnPanel.transform.DOMove(new Vector3(-1040, 540, 0), 1f);
        await UniTask.Delay(TimeSpan.FromSeconds(1));

        rouletteCanvas.gameObject.SetActive(true);

        //非表示
        turnObj.gameObject.SetActive(false);

    }
}
