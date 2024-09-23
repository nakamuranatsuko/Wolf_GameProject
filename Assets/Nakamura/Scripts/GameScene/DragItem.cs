using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour//, IEndDragHandler
{
    private int layerNumber = 1;
    private int setlayerNumber = 2;

    public static bool ItemDragFlg = false;

    private Vector3 screenPoint;
    private Vector3 offset;
    private bool collisionFlg = false;

    private WolfInputSystem wolfInputSystem;
    Vector2 move;

    private void Start()
    {
        wolfInputSystem = new WolfInputSystem();
        wolfInputSystem.Enable();
    }


    /// <summary>
    /// オブジェクトをクリックした瞬間
    /// </summary>
    //void OnMouseDown()
    //{
    //    //動かせるようにする
    //    collisionFlg = false;
    //    //場所を保存
    //    screenPoint = Camera.main.WorldToScreenPoint(transform.position);
    //    offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    //}

    /// <summary>
    /// オブジェクトをドラッグしている間
    /// </summary>
    //void OnMouseDrag()
    //{
    //    //同じ名前じゃないものはドラッグしない
    //    if (this.gameObject.name != RouletteManager.ItemName) return;

    //    //ドラッグしている間trueにする
    //    ItemDragFlg = true;
    //    //レイヤーを一つ上にあげる
    //    this.GetComponent<SpriteRenderer>().sortingOrder = setlayerNumber;
    //    //bodyTypeをDynamicにする
    //    this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

    //    //衝突している間は動かさない
    //    if (collisionFlg == true) return;
    //    //移動
    //    Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    //    Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
    //    transform.position = currentPosition;
    //}

    /// <summary>
    /// オブジェクトを離した瞬間
    /// </summary>
    /// <param name="data"></param>
    //public void OnEndDrag(PointerEventData data)
    //{
    //    //ドラッグが終了したらfalseにする
    //    ItemDragFlg = false;
    //    //レイヤーを戻す
    //    this.GetComponent<SpriteRenderer>().sortingOrder = layerNumber;
    //    //bodyTypeをKinematicに戻す
    //    this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //指定のTagに当ったら
    //    if(collision.gameObject.CompareTag("Wall"))
    //    {
    //        //動かせないようにする
    //        collisionFlg = true;
    //        Debug.Log("ぶつかった");
    //    }
    //}



    // ボタンを押したときtrue、離したときfalseになるフラグ
    private bool buttonDownFlag = false;
    private void Update()
    {
        if (buttonDownFlag)
        {
            // ボタンが押しっぱなしの状態の時にのみ「Hold」を表示する。
            Debug.Log("Hold");

            //同じ名前じゃないものはドラッグしない
            if (this.gameObject.name != RouletteManager.ItemName) return;

            //ドラッグしている間trueにする
            ItemDragFlg = true;
            //レイヤーを一つ上にあげる
            this.GetComponent<SpriteRenderer>().sortingOrder = setlayerNumber;
            //bodyTypeをDynamicにする
            //this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            //衝突している間は動かさない
            if (collisionFlg == true) return;
            //移動
            move = wolfInputSystem.Player.Move.ReadValue<Vector2>();
            //Vector3 currentScreenPoint = new Vector3(move.x, move.y, 0);
            //Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
            //transform.position = currentPosition;
            transform.position = new Vector3(move.x, move.y, 0);
        }
    }
    // ボタンを押したときの処理
    public void OnButtonDown()
    {
        //Debug.Log("Down");
        buttonDownFlag = true;

        //動かせるようにする
        collisionFlg = false;
        //場所を保存
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(move.x,move.y, screenPoint.z));
    }
    // ボタンを離したときの処理
    public void OnButtonUp()
    {
        //Debug.Log("Up");
        buttonDownFlag = false;

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
        if (collision.gameObject.CompareTag("Wall"))
        {
            //動かせないようにする
            collisionFlg = true;
            Debug.Log("ぶつかった");
        }
    }
}
