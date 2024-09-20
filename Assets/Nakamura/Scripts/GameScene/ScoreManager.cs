using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private GameObject[] targetItem;
    private List<GameObject> itemList = new List<GameObject>();
    //private string itemTag = "Item";

    [SerializeField]
    private string itemTag1 = "Fish";
    [SerializeField]
    private string itemTag2 = "Meat";
    [SerializeField]
    private string itemTag3 = "Shield";
    [SerializeField]
    private string itemTag4 = "Sword";

    private float itemHeight = -1.7f;
    private float itemWidth_plus = 1;
    private float itemWidth_minus = -1;

    private void Start()
    {
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

        foreach (var item in itemList)
        {
            //高さがオオカミに近いなら
            if (item.transform.position.y == itemHeight)
            {
                //内側にあれば
                if (item.transform.position.x == itemWidth_plus || item.transform.position.x == itemWidth_minus)
                {
                    item.tag = "firstScoreItem";
                }
                else
                {
                    item.tag = "secondScoreItem";
                }
            }
            else
            {
                if (item.transform.position.x == itemWidth_plus || item.transform.position.x == itemWidth_minus)
                {
                    item.tag = "thirdScoreItem";
                }
                else
                {
                    item.tag = "fourthScoreItem";
                }
            }
            Debug.Log(item.tag);
        }
    }
}
