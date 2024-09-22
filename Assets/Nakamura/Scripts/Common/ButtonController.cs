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
    /// �V�[����ǂݍ���
    /// </summary>
    public async void ChangeScene()
    {
        //SE
        SeManager.Instance.PlaySE(4);
        await FadeManager.Inctance.FadeOut();
        await SceneManager.LoadSceneAsync(sceneName);
    }

    /// <summary>
    /// �^�C�g���֖߂��ʂ�\��
    /// </summary>
    public void SwitchingOnGoToTitleCanvas()
    {
        //SE
        SeManager.Instance.PlaySE(4);
        goToTitleCanvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// �^�C�g���֖߂��ʂ��\��
    /// </summary>
    public void SwitchingOffGoToTitleCanvas()
    {
        //SE
        SeManager.Instance.PlaySE(4);
        goToTitleCanvas.gameObject.SetActive(false);
    }

    /// <summary>
    /// �Q�[��������ʂ��\��
    /// </summary>
    public void SwitchingOffHowToPlayCanvas()
    {
        //SE
        SeManager.Instance.PlaySE(4);
        howToPlayCanvas.gameObject.SetActive(false);
    }
}
