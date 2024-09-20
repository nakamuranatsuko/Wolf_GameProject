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

    //�A�C�e�����������true
    public static bool ItemFlg = false;
    //30�b�o������true
    public static bool TimeFlg = false;
    //�ق��̏����Ń^�[����サ����true
    public static bool CountFlg = false;
    //�T���N������true
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

    void Start()
    {
        //�����l
        TurnFlg = false;
        ItemFlg = false;
        TimeFlg = false;
        CountFlg = false;
        WolfFlg = false;
        resultFlg = false;
        ResultFlg = false;
        turnCount = 0;
        turnCountText.text = ((uint)turnCount + 1) + " / 8";

        TurnAlternation();
    }

    private async void Update()
    {
        //P1��P2�̏��Ԃ��S�^�[������ă��U���g�ֈڍs

        if (resultFlg) return;

        //�A�C�e�������w�ɓ��ꂽ��
        if (ItemFlg)
        {
            //�^�[�������
            TurnFlg = !TurnFlg;
            turnCount++;
            Debug.Log("�^�[�����");
            TurnAlternation();
            ItemFlg = false;
            CountFlg = true;
            //�J�E���g��MAX�ȊO�Ȃ�\��
            if (turnCount != 8) turnCountText.text = ((uint)turnCount + 1) + " / 8";
            //�h���b�O���Ă���Ԃɓ�������false�ɂ���
            DragItem.ItemDragFlg = false;

            if (turnCount != 8) await turnStart.TurnChange();
        }

        //30�b�o������
        else if (TimeFlg)
        {
            //�^�[�������
            TurnFlg = !TurnFlg;
            turnCount++;
            Debug.Log("�^�[�����");
            TurnAlternation();
            TimeFlg = false;
            CountFlg = true;
            //�J�E���g��MAX�ȊO�Ȃ�\��
            if (turnCount != 8) turnCountText.text = ((uint)turnCount + 1) + " / 8";
            //�h���b�O���Ă���Ԃɓ�������false�ɂ���
            DragItem.ItemDragFlg = false;

            if (turnCount != 8) await turnStart.TurnChange();
        }

        //�T���N������
        else if (WolfFlg)
        {
            //�^�[�������
            TurnFlg = !TurnFlg;
            turnCount++;
            Debug.Log("�^�[�����");
            TurnAlternation();
            WolfFlg = false;
            CountFlg = true;
            //�J�E���g��MAX�ȊO�Ȃ�\��
            if (turnCount != 8)turnCountText.text = ((uint)turnCount + 1) + " / 8";
            //�h���b�O���Ă���Ԃɓ�������false�ɂ���
            DragItem.ItemDragFlg = false;

            if (turnCount != 8) await turnStart.TurnChange();
        }

        //8���サ����
        if(turnCount == 8)
        {
            //�J��Ԃ���h��
            resultFlg = true;
            //���U���g�ֈڍs
            await ResultScene(sceneName);
            
        }
    }

    /// <summary>
    /// ���U���g�֑J�ڈڍs
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    private async UniTask ResultScene(string sceneName)
    {
        await FadeManager.Inctance.FadeOut();
        await SceneManager.LoadSceneAsync(sceneName);
    }

    /// <summary>
    /// �^�[�����̃e�L�X�g�̓���ւ�
    /// </summary>
    private void TurnAlternation()
    {
        //�^�[���J�E���g�������Ȃ�
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
