using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI P1ScoreText;
    [SerializeField]
    private TextMeshProUGUI P2ScoreText;
    [SerializeField]
    private Image p1DrawImage;
    [SerializeField]
    private Image p2DrawImage;
    [SerializeField]
    private Image winAnimation;
    [SerializeField]
    private Image loseAnimation;
    [SerializeField]
    private Transform p1Position;
    [SerializeField]
    private Transform p2Position;
    [SerializeField]
    private Image resultWolf;
    [SerializeField]
    private Image resultWolfDraw;

    private Vector2 p1RectTrans;
    private Vector2 p2RectTrans;

    private int p1Score = 0;
    private int p2Score = 0;

    private void Start()
    {
        p1Score = GameJudgement.P1Score;
        p2Score = GameJudgement.P2Score;

        p1RectTrans = transform.InverseTransformPoint(p1Position.position);
        p2RectTrans = transform.InverseTransformPoint(p2Position.position);

        resultWolf.gameObject.SetActive(true);
        resultWolfDraw.gameObject.SetActive(false);

        //p1Ç™èüÇ¡ÇƒÇΩÇÁ
        if (p2Score < p1Score)
        {
            P1ScoreText.text = p1Score.ToString();
            p1DrawImage.gameObject.SetActive(false);
            winAnimation.gameObject.SetActive(true);
            winAnimation.gameObject.transform.position = p1RectTrans;

            P2ScoreText.text = p2Score.ToString();
            p2DrawImage.gameObject.SetActive(false);
            loseAnimation.gameObject.SetActive(true);
            loseAnimation.gameObject.transform.position = p2RectTrans;
        }

        //p2Ç™èüÇ¡ÇƒÇΩÇÁ
        if (p1Score < p2Score)
        {
            P2ScoreText.text = p2Score.ToString();
            p2DrawImage.gameObject.SetActive(false);
            winAnimation.gameObject.SetActive(true);
            winAnimation.gameObject.transform.position = p2RectTrans;

            P1ScoreText.text = p1Score.ToString();
            p1DrawImage.gameObject.SetActive(false);
            loseAnimation.gameObject.SetActive(true);
            loseAnimation.gameObject.transform.position = p1RectTrans;
        }

        //à¯Ç´ï™ÇØ
        if(p1Score == p2Score)
        {
            P1ScoreText.text = p1Score.ToString();
            P2ScoreText.text = p2Score.ToString();
            p1DrawImage.gameObject.SetActive(true);
            p2DrawImage.gameObject.SetActive(true);
            winAnimation.gameObject.SetActive(false);
            loseAnimation.gameObject.SetActive(false);

            if (p1Score == 0 && p2Score == 0)
            {
                resultWolf.gameObject.SetActive(false);
                resultWolfDraw.gameObject.SetActive(true);
            }
        }
    }
}
