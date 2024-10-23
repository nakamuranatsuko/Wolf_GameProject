using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    [SerializeField]
    private float time = 30;
    [SerializeField]
    private TextMeshProUGUI timeText;
    //タイムリセット用
    private float turnTime;

    [SerializeField]
    private GameObject howToPlayCanvas;
    [SerializeField]
    private GameObject goToTitleCanvas;
    [SerializeField]
    private GameObject turnStartCanvas;
    //ルーレットの画面
    [SerializeField]
    private GameObject rouletteCanvas;

    void Start()
    {
        turnTime = time;
    }

    void Update()
    {
        //ゲーム以外の画面なら下の処理に行かない(ガード節)
        if (howToPlayCanvas.activeSelf) return;
        if (goToTitleCanvas.activeSelf) return;
        if (turnStartCanvas.activeSelf) return;
        if (rouletteCanvas.activeSelf) return;

        time -= Time.deltaTime;
        timeText.text = time.ToString("00");

        //timeが0以下の時に実行
        if (time <= 0)
        {
            //時間をリセット
            time = turnTime;
            //ターン交代
            TurnChangeManager.TimeFlg = true;
        }

        //ほかの条件でターン交代したら
        if (TurnChangeManager.CountFlg)
        {
            //時間をリセット
            time = turnTime;
        }
    }
}
