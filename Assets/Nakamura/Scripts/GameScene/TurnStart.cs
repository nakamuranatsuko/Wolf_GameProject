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
        //�\��
        turnObj.gameObject.SetActive(true);

        //�����~�܂�
        await UniTask.Delay(TimeSpan.FromSeconds(3));

        //�����ʒu��
        turnPanel.transform.position = new Vector3(2000, 540, 0);
        //������^�񒆂�
        turnPanel.transform.DOMove(new Vector3(960, 540, 0), 1f);
        //�����~�܂�
        await UniTask.Delay(TimeSpan.FromSeconds(2));
        //�^�񒆂���E��
        turnPanel.transform.DOMove(new Vector3(-1040, 540, 0), 1f);
        await UniTask.Delay(TimeSpan.FromSeconds(1));

        rouletteCanvas.gameObject.SetActive(true);

        //��\��
        turnObj.gameObject.SetActive(false);

    }
}
