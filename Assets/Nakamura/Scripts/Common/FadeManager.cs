using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

[RequireComponent(typeof(CanvasGroup))]
public class FadeManager : MonoBehaviour
{
    [SerializeField]
    private float _fadeSpeed = 1f;

    private CanvasGroup _canvasGroup;

    private static FadeManager _instance;
    public static FadeManager Inctance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<FadeManager>();

                if (_instance == null)
                {
                    var obj = new GameObject("FadeManager");
                    _instance = obj.AddComponent<FadeManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    /// <summary>
    /// フェードイン
    /// </summary>
    public async UniTask FadeIn()
    {
        this.gameObject.SetActive(true);
        _canvasGroup.alpha = 1;
        float alpha = 1;
        while (_canvasGroup.alpha > 0)
        {
            alpha -= Time.deltaTime * _fadeSpeed;
            _canvasGroup.alpha = Mathf.Max(alpha, 0f);
            await UniTask.Yield();
        }
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// フェードアウト
    /// </summary>
    public async UniTask FadeOut()
    {
        this.gameObject.SetActive(true);
        _canvasGroup.alpha = 0;
        float alpha = 0;
        while (_canvasGroup.alpha < 1)
        {
            alpha += Time.deltaTime * _fadeSpeed;
            _canvasGroup.alpha = Mathf.Min(alpha, 1f);
            await UniTask.Yield();
        }
        //this.gameObject.SetActive(false);
    }
}
