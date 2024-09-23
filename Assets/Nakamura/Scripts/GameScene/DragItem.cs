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
    /// �I�u�W�F�N�g���N���b�N�����u��
    /// </summary>
    //void OnMouseDown()
    //{
    //    //��������悤�ɂ���
    //    collisionFlg = false;
    //    //�ꏊ��ۑ�
    //    screenPoint = Camera.main.WorldToScreenPoint(transform.position);
    //    offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    //}

    /// <summary>
    /// �I�u�W�F�N�g���h���b�O���Ă����
    /// </summary>
    //void OnMouseDrag()
    //{
    //    //�������O����Ȃ����̂̓h���b�O���Ȃ�
    //    if (this.gameObject.name != RouletteManager.ItemName) return;

    //    //�h���b�O���Ă����true�ɂ���
    //    ItemDragFlg = true;
    //    //���C���[�����ɂ�����
    //    this.GetComponent<SpriteRenderer>().sortingOrder = setlayerNumber;
    //    //bodyType��Dynamic�ɂ���
    //    this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

    //    //�Փ˂��Ă���Ԃ͓������Ȃ�
    //    if (collisionFlg == true) return;
    //    //�ړ�
    //    Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    //    Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
    //    transform.position = currentPosition;
    //}

    /// <summary>
    /// �I�u�W�F�N�g�𗣂����u��
    /// </summary>
    /// <param name="data"></param>
    //public void OnEndDrag(PointerEventData data)
    //{
    //    //�h���b�O���I��������false�ɂ���
    //    ItemDragFlg = false;
    //    //���C���[��߂�
    //    this.GetComponent<SpriteRenderer>().sortingOrder = layerNumber;
    //    //bodyType��Kinematic�ɖ߂�
    //    this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //�w���Tag�ɓ�������
    //    if(collision.gameObject.CompareTag("Wall"))
    //    {
    //        //�������Ȃ��悤�ɂ���
    //        collisionFlg = true;
    //        Debug.Log("�Ԃ�����");
    //    }
    //}



    // �{�^�����������Ƃ�true�A�������Ƃ�false�ɂȂ�t���O
    private bool buttonDownFlag = false;
    private void Update()
    {
        if (buttonDownFlag)
        {
            // �{�^�����������ςȂ��̏�Ԃ̎��ɂ̂݁uHold�v��\������B
            Debug.Log("Hold");

            //�������O����Ȃ����̂̓h���b�O���Ȃ�
            if (this.gameObject.name != RouletteManager.ItemName) return;

            //�h���b�O���Ă����true�ɂ���
            ItemDragFlg = true;
            //���C���[�����ɂ�����
            this.GetComponent<SpriteRenderer>().sortingOrder = setlayerNumber;
            //bodyType��Dynamic�ɂ���
            //this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            //�Փ˂��Ă���Ԃ͓������Ȃ�
            if (collisionFlg == true) return;
            //�ړ�
            move = wolfInputSystem.Player.Move.ReadValue<Vector2>();
            //Vector3 currentScreenPoint = new Vector3(move.x, move.y, 0);
            //Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
            //transform.position = currentPosition;
            transform.position = new Vector3(move.x, move.y, 0);
        }
    }
    // �{�^�����������Ƃ��̏���
    public void OnButtonDown()
    {
        //Debug.Log("Down");
        buttonDownFlag = true;

        //��������悤�ɂ���
        collisionFlg = false;
        //�ꏊ��ۑ�
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(move.x,move.y, screenPoint.z));
    }
    // �{�^���𗣂����Ƃ��̏���
    public void OnButtonUp()
    {
        //Debug.Log("Up");
        buttonDownFlag = false;

        //�h���b�O���I��������false�ɂ���
        ItemDragFlg = false;
        //���C���[��߂�
        this.GetComponent<SpriteRenderer>().sortingOrder = layerNumber;
        //bodyType��Kinematic�ɖ߂�
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�w���Tag�ɓ�������
        if (collision.gameObject.CompareTag("Wall"))
        {
            //�������Ȃ��悤�ɂ���
            collisionFlg = true;
            Debug.Log("�Ԃ�����");
        }
    }
}
