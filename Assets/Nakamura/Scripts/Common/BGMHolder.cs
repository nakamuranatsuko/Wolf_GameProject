using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BGMRack
{
    //ディクショナリー
    public static
        Dictionary<string,AudioClip> AudioClips = new Dictionary<string, AudioClip>();
}

public class BGMHolder:MonoBehaviour
{
    //独自のクラスをインスペクター上に載せるため
    [System.Serializable]
    public class AudioData
    {
        public string name;
        public AudioClip audioClip;
    }

    [SerializeField]
    private List<AudioData> _listAudioData = new List<AudioData>();

    private void Start()
    {
        //フォーイーチ:配列に含まれる要素を順番に取り出して処理する
        foreach (var ad in _listAudioData)
        {
            BGMRack.AudioClips.Add(ad.name, ad.audioClip);
        }
    }
}
