using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine.UI;
using System;

public class TurnChangeManager : MonoBehaviour
{
    //false:P1 true:P2
    public static bool TurnFlg = false;

    //アイテムを取ったらtrue
    public static bool ItemFlg = false;
    //30秒経ったらtrue
    public static bool TimeFlg = false;
    //ほかの条件でターン交代したらtrue
    public static bool CountFlg = false;
    //狼が起きたらtrue
    public static bool WolfFlg = false;

    private bool resultFlg = false;

    private int turnCount = 0;

    [SerializeField]
    private Canvas FadeCanvas;

    [SerializeField]
    private string sceneName;

    [SerializeField]
    private TurnStart turnStart;
    [SerializeField]
    private Image p1TurnImage;
    [SerializeField]
    private Image p2TurnImage;
    [SerializeField]
    private TextMeshProUGUI turnCountText;

    public static bool ResultFlg = false;

    private bool finishWolfFlg = false;

    void Start()
    {
        //初期値
        TurnFlg = false;
        ItemFlg = false;
        TimeFlg = false;
        CountFlg = false;
        WolfFlg = false;
        resultFlg = false;
        ResultFlg = false;
        finishWolfFlg = false;
        turnCount = 0;
        turnCountText.text = ((uint)turnCount + 1) + " / 8";

        TurnAlternation();
    }

    private async void Update()
    {
        //P1→P2の順番を４ターンやってリザルトへ移行

        if (resultFlg) return;

        //アイテムを自陣に入れたら
        if (ItemFlg)
        {
            //ターンを交代
            TurnFlg = !TurnFlg;
            turnCount++;
            Debug.Log("ターン交代");
            TurnAlternation();
            ItemFlg = false;
            CountFlg = true;
            RouletteManager.ItemName = "None";
            //カウントがMAX以外なら表示
            if (turnCount != 8) turnCountText.text = ((uint)turnCount + 1) + " / 8";
            //ドラッグしている間に入ったらfalseにする
            DragItem.ItemDragFlg = false;
            //SE
            SeManager.Instance.PlaySE(5,0.7f);
            //少し待つ
            if (turnCount != 8) await UniTask.Delay(TimeSpan.FromSeconds(0.5));
            CountFlg = false;

            if (turnCount != 8) await turnStart.TurnChange();
        }

        //30秒経ったら
        else if (TimeFlg)
        {
            //ターンを交代
            TurnFlg = !TurnFlg;
            turnCount++;
            Debug.Log("ターン交代");
            TurnAlternation();
            TimeFlg = false;
            CountFlg = true;
            RouletteManager.ItemName = "None";
            //カウントがMAX以外なら表示
            if (turnCount != 8) turnCountText.text = ((uint)turnCount + 1) + " / 8";
            //ドラッグしている間に入ったらfalseにする
            DragItem.ItemDragFlg = false;

            if (turnCount != 8) await turnStart.TurnChange();
        }

        //狼が起きたら
        else if (WolfFlg)
        {
            //ターンを交代
            TurnFlg = !TurnFlg;
            turnCount++;
            Debug.Log("ターン交代");
            TurnAlternation();
            WolfFlg = false;
            CountFlg = true;
            RouletteManager.ItemName = "None";
            //カウントがMAX以外なら表示
            if (turnCount != 8)turnCountText.text = ((uint)turnCount + 1) + " / 8";
            //ドラッグしている間に入ったらfalseにする
            DragItem.ItemDragFlg = false;
            //少し待つ
            if(turnCount != 8)await UniTask.Delay(TimeSpan.FromSeconds(3));
            CountFlg = false;

            if (turnCount != 8) await turnStart.TurnChange();
            if (turnCount == 8) finishWolfFlg = true;
        }

        //8回交代したら
        if(turnCount == 8)
        {
            //繰り返しを防ぐ
            resultFlg = true;
            //リザルトへ移行
            await ResultScene(sceneName);
            
        }
    }

    /// <summary>
    /// リザルトへ遷移移行
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    private async UniTask ResultScene(string sceneName)
    {
        //最後がオオカミで終わったら少し待つ
        if (finishWolfFlg == true) await UniTask.Delay(TimeSpan.FromSeconds(3));
        await FadeManager.Inctance.FadeOut();
        await SceneManager.LoadSceneAsync(sceneName);
    }

    /// <summary>
    /// ターン交代のテキストの入れ替え
    /// </summary>
    private void TurnAlternation()
    {
        //ターンカウントが偶数なら
        if(turnCount % 2 == 0)
        {
            p1TurnImage.gameObject.SetActive(true);
            p2TurnImage.gameObject.SetActive(false);
        }
        else
        {
            p2TurnImage.gameObject.SetActive(true);
            p1TurnImage.gameObject.SetActive(false);
        }
    }
}
