using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    public async UniTask ChangeScene()
    {
        await GameScene(sceneName);
    }

    private async UniTask GameScene(string sceneName)
    {
        await FadeManager.Inctance.FadeOut();
        await SceneManager.LoadSceneAsync(sceneName);
    }
}
