using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPositionManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> itemObj;
    [SerializeField]
    public List<Vector2> itemPos;

    private void Awake()
    {
        for(int i = 0;i < itemObj.Count;i++)
        {
            //位置情報の数分だけランダムに決める
            int rnd = Random.Range(0, itemPos.Count);
            //オブジェクトにランダムに決めた位置を入れる
            itemObj[i].transform.position = itemPos[rnd];
            //使った位置情報は削除
            itemPos.RemoveAt(rnd);
        }
    }
}
