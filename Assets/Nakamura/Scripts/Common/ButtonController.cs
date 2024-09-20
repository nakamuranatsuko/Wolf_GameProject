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
        await FadeManager.Inctance.FadeOut();
        await SceneManager.LoadSceneAsync(sceneName);
    }

    /// <summary>
    /// �^�C�g���֖߂��ʂ�\��
    /// </summary>
    public void SwitchingOnGoToTitleCanvas()
    {
        goToTitleCanvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// �^�C�g���֖߂��ʂ��\��
    /// </summary>
    public void SwitchingOffGoToTitleCanvas()
    {
        goToTitleCanvas.gameObject.SetActive(false);
    }

    /// <summary>
    /// �Q�[��������ʂ��\��
    /// </summary>
    public void SwitchingOffHowToPlayCanvas()
    {
        howToPlayCanvas.gameObject.SetActive(false);
    }
}
