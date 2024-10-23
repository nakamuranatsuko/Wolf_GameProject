using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IEndDragHandler//,IBeginDragHandler, IDragHandler
{
    private int layerNumber = 1;
    private int setlayerNumber = 2;

    public static bool ItemDragFlg = false;

    private Vector3 screenPoint;
    private Vector3 offset;
    private bool collisionFlg = false;

    private string itemTag1 = "Fish";
    private string itemTag2 = "Meat";
    private string itemTag3 = "Shield";
    private string itemTag4 = "Sword";

    public static Vector2 FishPos;
    public static Vector2 MeatPos;
    public static Vector2 ShieldPos;
    public static Vector2 SwordPos;

    void Start()
    {
        //初期位置
        if (gameObject.CompareTag(itemTag1)) FishPos = transform.position;
        if (gameObject.CompareTag(itemTag2)) MeatPos = transform.position;
        if (gameObject.CompareTag(itemTag3)) ShieldPos = transform.position;
        if (gameObject.CompareTag(itemTag4)) SwordPos = transform.position;
    }

    /// <summary>
    /// オブジェクトをクリックした瞬間
    /// </summary>
    void OnMouseDown()
    {
        //動かせるようにする
        collisionFlg = false;
        //場所を保存
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    /// <summary>
    /// オブジェクトをドラッグしている間
    /// </summary>
    void OnMouseDrag()
    {
        //同じ名前じゃないものはドラッグしない
        if (this.gameObject.name != RouletteManager.ItemName) return;

        //ドラッグしている間trueにする
        ItemDragFlg = true;
        //レイヤーを一つ上にあげる
        this.GetComponent<SpriteRenderer>().sortingOrder = setlayerNumber;
        //bodyTypeをDynamicにする
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        //衝突している間は動かさない
        if (collisionFlg == true) return;
        //移動
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
        transform.position = currentPosition;
    }

    /// <summary>
    /// オブジェクトを離した瞬間
    /// </summary>
    /// <param name="data"></param>
    public void OnEndDrag(PointerEventData data)
    {
        //ドラッグが終了したらfalseにする
        ItemDragFlg = false;
        //レイヤーを戻す
        this.GetComponent<SpriteRenderer>().sortingOrder = layerNumber;
        //bodyTypeをKinematicに戻す
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //指定のTagに当ったら
        if(collision.gameObject.CompareTag("Wall"))
        {
            //動かせないようにする
            collisionFlg = true;
            Debug.Log("ぶつかった");
        }
    }
}
