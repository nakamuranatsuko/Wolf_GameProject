using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private Canvas goToTitleCanvas;
    [SerializeField]
    private Canvas howToPlayCanvas;
    [SerializeField]
    private Canvas FadeCanvas;

    /// <summary>
    /// シーンを読み込む
    /// </summary>
    public async void ChangeScene()
    {
        //SE
        SeManager.Instance.PlaySE(4);
        await FadeManager.Inctance.FadeOut();
        await SceneManager.LoadSceneAsync(sceneName);
    }

    /// <summary>
    /// タイトルへ戻る画面を表示
    /// </summary>
    public void SwitchingOnGoToTitleCanvas()
    {
        //SE
        SeManager.Instance.PlaySE(4);
        goToTitleCanvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// タイトルへ戻る画面を非表示
    /// </summary>
    public void SwitchingOffGoToTitleCanvas()
    {
        //SE
        SeManager.Instance.PlaySE(4);
        goToTitleCanvas.gameObject.SetActive(false);
    }

    /// <summary>
    /// ゲーム説明画面を非表示
    /// </summary>
    public void SwitchingOffHowToPlayCanvas()
    {
        //SE
        SeManager.Instance.PlaySE(4);
        howToPlayCanvas.gameObject.SetActive(false);
    }
}
