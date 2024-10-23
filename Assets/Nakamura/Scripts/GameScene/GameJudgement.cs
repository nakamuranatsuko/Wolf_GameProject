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

    //�X�R�A
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
        //�����l
        P1Score = 0;
        P2Score = 0;
        score = 0;
        //���[���b�g�p�̃J�E���g���Z�b�g
        RouletteManager.FishCount = 0;
        RouletteManager.MeatCount = 0;
        RouletteManager.ShieldCount = 0;
        RouletteManager.SwordCount = 0;

        //Item�^�O�����Ă���̂�S�Ď擾����
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
        //�A�C�e�����d�Ȃ��Ă��邩����
        foreach (var item in itemList)
        {
            Bounds _bounds = item.GetComponent<Collider2D>().bounds;
            if (_bounds.Contains(gameObject.transform.position))
            {
                //�^�O���r���ē��_������U��
                if (item.gameObject.CompareTag(firstTag)) score = firstScore;
                if (item.gameObject.CompareTag(secondTag)) score = secondScore;
                if (item.gameObject.CompareTag(thirdTag)) score = thirdScore;
                if (item.gameObject.CompareTag(fourthTag)) score = fourthScore;

                //�����ɓ����Ă����A�C�e���̖��O�ƃ��[���b�g�Ŏw�肳�ꂽ���O���������
                if (item.gameObject.name != RouletteManager.ItemName)
                {
                    //�����ʒu
                    if (item.gameObject.name == "Fish") item.gameObject.transform.position = DragItem.FishPos;
                    if (item.gameObject.name == "Meat") item.gameObject.transform.position = DragItem.MeatPos;
                    if (item.gameObject.name == "Shield") item.gameObject.transform.position = DragItem.ShieldPos;
                    if (item.gameObject.name == "Sword") item.gameObject.transform.position = DragItem.SwordPos;
                    return;
                }

                    //���g�̃^�O�𔻒�
                    PlayerTag(score);

                //�A�C�e�����\��
                if (itemGetFlg)
                {
                    item.SetActive(false);

                    //������A�C�e�����J�E���g����
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
    /// ���g�̃^�O�𔻒肷��
    /// </summary>
    /// <param name="itemScore">�A�C�e���̓��_</param>
    private void PlayerTag(int itemScore)
    {
        //�����̔Ԃ���Ȃ������疳���ɂ���(P1:false)
        if (TurnChangeManager.TurnFlg == false)
        {
            //���g�̃^�O�� P1Basket �Ȃ�
            if (this.gameObject.CompareTag(p1BasketTag))
            {
                //�_�������Z
                P1Score += itemScore;
                Debug.Log("P1Basket Score:" + P1Score);
                //�^�[�������
                TurnChangeManager.ItemFlg = true;
                //�t���O�����Ă�
                itemGetFlg = true;
            }
        }


        //�����̔Ԃ���Ȃ������疳���ɂ���(P2:true)
        if (TurnChangeManager.TurnFlg == true)
        {
            //���g�̃^�O�� P2Basket �Ȃ�
            if (this.gameObject.CompareTag(p2BasketTag))
            {
                //�_�������Z
                P2Score += itemScore;
                Debug.Log("P2Basket Score:" + P2Score);
                //�^�[�������
                TurnChangeManager.ItemFlg = true;
                //�t���O�����Ă�
                itemGetFlg = true;
            }
        }

    }
}
