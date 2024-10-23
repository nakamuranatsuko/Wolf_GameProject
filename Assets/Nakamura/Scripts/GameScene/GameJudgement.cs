using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameJudgement : MonoBehaviour
{
    private GameObject[] targetItem;
    private List<GameObject> itemList = new List<GameObject>();

    private string p1BasketTag = "P1Basket";
    private string p2BasketTag = "P2Basket";
    //private string itemTag = "Item";

    [SerializeField]
    private string itemTag1 = "Fish";
    [SerializeField]
    private string itemTag2 = "Meat";
    [SerializeField]
    private string itemTag3 = "Shield";
    [SerializeField]
    private string itemTag4 = "Sword";

    private bool itemGetFlg = false;

    //スコア
    public static int P1Score = 0;
    public static int P2Score = 0;

    private int score = 0;

    private int firstScore = 5;
    private int secondScore = 4;
    private int thirdScore = 3;
    private int fourthScore = 2;

    private string firstTag = "firstScoreItem";
    private string secondTag = "secondScoreItem";
    private string thirdTag = "thirdScoreItem";
    private string fourthTag = "fourthScoreItem";

    private void Awake()
    {
        //初期値
        P1Score = 0;
        P2Score = 0;
        score = 0;
        //ルーレット用のカウントリセット
        RouletteManager.FishCount = 0;
        RouletteManager.MeatCount = 0;
        RouletteManager.ShieldCount = 0;
        RouletteManager.SwordCount = 0;

        //Itemタグがついてるものを全て取得する
        targetItem = GameObject.FindGameObjectsWithTag(itemTag1);
        foreach (var item in targetItem)
        {
            itemList.Add(item);
        }
        targetItem = GameObject.FindGameObjectsWithTag(itemTag2);
        foreach (var item in targetItem)
        {
            itemList.Add(item);
        }
        targetItem = GameObject.FindGameObjectsWithTag(itemTag3);
        foreach (var item in targetItem)
        {
            itemList.Add(item);
        }
        targetItem = GameObject.FindGameObjectsWithTag(itemTag4);
        foreach (var item in targetItem)
        {
            itemList.Add(item);
        }
    }

    private void Update()
    {
        //アイテムが重なっているか判定
        foreach (var item in itemList)
        {
            Bounds _bounds = item.GetComponent<Collider2D>().bounds;
            if (_bounds.Contains(gameObject.transform.position))
            {
                //タグを比較して得点を割り振る
                if (item.gameObject.CompareTag(firstTag)) score = firstScore;
                if (item.gameObject.CompareTag(secondTag)) score = secondScore;
                if (item.gameObject.CompareTag(thirdTag)) score = thirdScore;
                if (item.gameObject.CompareTag(fourthTag)) score = fourthScore;

                //かごに入ってきたアイテムの名前とルーレットで指定された名前が違ったら
                if (item.gameObject.name != RouletteManager.ItemName)
                {
                    //初期位置
                    if (item.gameObject.name == "Fish") item.gameObject.transform.position = DragItem.FishPos;
                    if (item.gameObject.name == "Meat") item.gameObject.transform.position = DragItem.MeatPos;
                    if (item.gameObject.name == "Shield") item.gameObject.transform.position = DragItem.ShieldPos;
                    if (item.gameObject.name == "Sword") item.gameObject.transform.position = DragItem.SwordPos;
                    return;
                }

                    //自身のタグを判定
                    PlayerTag(score);

                //アイテムを非表示
                if (itemGetFlg)
                {
                    item.SetActive(false);

                    //取ったアイテムをカウントする
                    if (item.gameObject.name == itemTag1) RouletteManager.FishCount++;
                    if (item.gameObject.name == itemTag2) RouletteManager.MeatCount++;
                    if (item.gameObject.name == itemTag3) RouletteManager.ShieldCount++;
                    if (item.gameObject.name == itemTag4) RouletteManager.SwordCount++;
                    Debug.Log(RouletteManager.FishCount);
                    Debug.Log(RouletteManager.MeatCount);
                    Debug.Log(RouletteManager.ShieldCount);
                    Debug.Log(RouletteManager.SwordCount);

                    itemGetFlg = false;
                }
            }
        }
    }

    /// <summary>
    /// 自身のタグを判定する
    /// </summary>
    /// <param name="itemScore">アイテムの得点</param>
    private void PlayerTag(int itemScore)
    {
        //自分の番じゃなかったら無効にする(P1:false)
        if (TurnChangeManager.TurnFlg == false)
        {
            //自身のタグが P1Basket なら
            if (this.gameObject.CompareTag(p1BasketTag))
            {
                //点数を加算
                P1Score += itemScore;
                Debug.Log("P1Basket Score:" + P1Score);
                //ターンを交代
                TurnChangeManager.ItemFlg = true;
                //フラグをたてる
                itemGetFlg = true;
            }
        }


        //自分の番じゃなかったら無効にする(P2:true)
        if (TurnChangeManager.TurnFlg == true)
        {
            //自身のタグが P2Basket なら
            if (this.gameObject.CompareTag(p2BasketTag))
            {
                //点数を加算
                P2Score += itemScore;
                Debug.Log("P2Basket Score:" + P2Score);
                //ターンを交代
                TurnChangeManager.ItemFlg = true;
                //フラグをたてる
                itemGetFlg = true;
            }
        }

    }
}
