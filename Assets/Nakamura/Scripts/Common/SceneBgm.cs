using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBgm : MonoBehaviour
{
    void Start()
    {
        //if (SceneManager.GetActiveScene().name == "TitleScene")
        //{
        //    BGMPlayer.Instance.PlayBGM("start_bgm", 0.5f);
        //}
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            BGMPlayer.Instance.PlayBGM("Game_BGM_loop", 0.5f);
        }
        if (SceneManager.GetActiveScene().name == "ResultScene")
        {
            BGMPlayer.Instance.PlayBGM("Result_BGM_loop", 0.5f);
        }
    }
}
