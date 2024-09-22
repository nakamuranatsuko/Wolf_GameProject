using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Cysharp.Threading.Tasks;
using System;

public class RouletteManager : MonoBehaviour
{
    [SerializeField]
    private GameObject rouletteCanvas;

    public static string ItemName = "";

    [SerializeField]
    private List<VideoPlayer> rouletteAnimation = new List<VideoPlayer>();

    private int rouletteNum = 0;

    [SerializeField]
    private Image fishImage;
    [SerializeField]
    private Image meatImage;
    [SerializeField]
    private Image shieldImage;
    [SerializeField]
    private Image swordImage;

    [SerializeField]
    private GameObject rouletteImage;

[SerializeField]
    private GameObject rouletteItemImage;
    [SerializeField]
    private Image fishRouletteItem;
    [SerializeField]
    private Image meatRouletteItem;
    [SerializeField]
    private Image shieldRouletteItem;
    [SerializeField]
    private Image swordRouletteItem;

    public static int FishCount = 0;
    public static int MeatCount = 0;
    public static int ShieldCount = 0;
    public static int SwordCount = 0;

    private int turnCount = 0;

    private async void OnEnable()
    {
        //最初はアイテム非表示
        fishImage.gameObject.SetActive(false);
        meatImage.gameObject.SetActive(false);
        shieldImage.gameObject.SetActive(false);
        swordImage.gameObject.SetActive(false);
        rouletteItemImage.gameObject.SetActive(false);
        fishRouletteItem.gameObject.SetActive(false);
        meatRouletteItem.gameObject.SetActive(false);
        shieldRouletteItem.gameObject.SetActive(false);
        swordRouletteItem.gameObject.SetActive(false);

        rouletteImage.gameObject.SetActive(true);

        //ランダムで決める
        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
        //被りがあるか確認(2個以上取られていたら繰り返す)
        RandomItem();

        //再生開始
        rouletteAnimation[rouletteNum].gameObject.SetActive(true);
        rouletteAnimation[rouletteNum].loopPointReached += LoopPointReached;
        rouletteAnimation[rouletteNum].Play();

        //SE
        SeManager.Instance.PlaySE(14);
        //少し止まる
        await UniTask.Delay(TimeSpan.FromSeconds(2));
        SeManager.Instance.PlaySE(13);
    }

    /// <summary>
    /// 動画再生完了時の処理
    /// </summary>
    /// <param name="vp"></param>
    public async void LoopPointReached(VideoPlayer vp)
    {
        //少し止まる
        await UniTask.Delay(TimeSpan.FromSeconds(1));

        rouletteAnimation[rouletteNum].gameObject.SetActive(false);
        rouletteImage.gameObject.SetActive(false);

        rouletteItemImage.gameObject.SetActive(true);
        if (rouletteNum == 0) fishRouletteItem.gameObject.SetActive(true);
        if (rouletteNum == 1) meatRouletteItem.gameObject.SetActive(true);
        if (rouletteNum == 2) shieldRouletteItem.gameObject.SetActive(true);
        if (rouletteNum == 3) swordRouletteItem.gameObject.SetActive(true);
        //SE
        SeManager.Instance.PlaySE(15);

        //少し止まる
        await UniTask.Delay(TimeSpan.FromSeconds(2));

        if (rouletteNum == 0)
        {
            ItemName = "Fish";
            fishImage.gameObject.SetActive(true);
        }
        if (rouletteNum == 1)
        {
            ItemName = "Meat";
            meatImage.gameObject.SetActive(true);
        }
        if (rouletteNum == 2)
        {
            ItemName = "Shield";
            shieldImage.gameObject.SetActive(true);
        }
        if (rouletteNum == 3)
        {
            ItemName = "Sword";
            swordImage.gameObject.SetActive(true);
        }

        rouletteCanvas.gameObject.SetActive(false);
    }

    /// <summary>
    /// 被りがあるか確認(2個以上取られていたら繰り返す)
    /// </summary>
    private void RandomItem()
    {
        rouletteNum = UnityEngine.Random.Range(0, 4);
        //今の指定アイテムがすでに2個以上取っていたら繰り返す
        //最後のターン以外
        if (turnCount != 7)
        {
            if (rouletteNum == 0)
            {
                if (FishCount >= 2) RandomItem();
            }
            else if (rouletteNum == 1)
            {
                if (MeatCount >= 2) RandomItem();
            }
            else if (rouletteNum == 2)
            {
                if (ShieldCount >= 2) RandomItem();
            }
            else if (rouletteNum == 3)
            {
                if (SwordCount >= 2) RandomItem();
            }
        }
        else
        {
            if (FishCount < 2) rouletteNum = 0;
            if (MeatCount < 2) rouletteNum = 1;
            if (ShieldCount < 2) rouletteNum = 2;
            if (SwordCount < 2) rouletteNum = 3;
            turnCount = 0;
        }
    }
}
