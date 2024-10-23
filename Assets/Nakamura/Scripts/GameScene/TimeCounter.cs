using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    [SerializeField]
    private float time = 30;
    [SerializeField]
    private TextMeshProUGUI timeText;
    //�^�C�����Z�b�g�p
    private float turnTime;

    [SerializeField]
    private GameObject howToPlayCanvas;
    [SerializeField]
    private GameObject goToTitleCanvas;
    [SerializeField]
    private GameObject turnStartCanvas;
    //���[���b�g�̉��
    [SerializeField]
    private GameObject rouletteCanvas;

    void Start()
    {
        turnTime = time;
    }

    void Update()
    {
        //�Q�[���ȊO�̉�ʂȂ牺�̏����ɍs���Ȃ�(�K�[�h��)
        if (howToPlayCanvas.activeSelf) return;
        if (goToTitleCanvas.activeSelf) return;
        if (turnStartCanvas.activeSelf) return;
        if (rouletteCanvas.activeSelf) return;

        time -= Time.deltaTime;
        timeText.text = time.ToString("00");

        //time��0�ȉ��̎��Ɏ��s
        if (time <= 0)
        {
            //���Ԃ����Z�b�g
            time = turnTime;
            //�^�[�����
            TurnChangeManager.TimeFlg = true;
        }

        //�ق��̏����Ń^�[����サ����
        if (TurnChangeManager.CountFlg)
        {
            //���Ԃ����Z�b�g
            time = turnTime;
        }
    }
}
