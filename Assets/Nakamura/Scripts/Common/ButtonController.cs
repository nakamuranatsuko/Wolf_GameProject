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
        await FadeManager.Inctance.FadeOut();
        await SceneManager.LoadSceneAsync(sceneName);
    }

    /// <summary>
    /// タイトルへ戻る画面を表示
    /// </summary>
    public void SwitchingOnGoToTitleCanvas()
    {
        goToTitleCanvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// タイトルへ戻る画面を非表示
    /// </summary>
    public void SwitchingOffGoToTitleCanvas()
    {
        goToTitleCanvas.gameObject.SetActive(false);
    }

    /// <summary>
    /// ゲーム説明画面を非表示
    /// </summary>
    public void SwitchingOffHowToPlayCanvas()
    {
        howToPlayCanvas.gameObject.SetActive(false);
    }
}
