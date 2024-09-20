using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BGMRack
{
    //�f�B�N�V���i���[
    public static
        Dictionary<string,AudioClip> AudioClips = new Dictionary<string, AudioClip>();
}

public class BGMHolder:MonoBehaviour
{
    //�Ǝ��̃N���X���C���X�y�N�^�[��ɍڂ��邽��
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
        //�t�H�[�C�[�`:�z��Ɋ܂܂��v�f�����ԂɎ��o���ď�������
        foreach (var ad in _listAudioData)
        {
            BGMRack.AudioClips.Add(ad.name, ad.audioClip);
        }
    }
}
