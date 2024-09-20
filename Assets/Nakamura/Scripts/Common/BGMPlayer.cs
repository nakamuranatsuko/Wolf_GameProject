using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    private static BGMPlayer _instance = null;
    public static BGMPlayer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<BGMPlayer>();

                if (_instance == null)
                {
                    GameObject obj = new GameObject("BGMPlayer");
                    _instance = obj.AddComponent<BGMPlayer>();
                }
            }
            return _instance;
        }
    }

    [SerializeField]
    private AudioSource _asSE;

    [SerializeField]
    private AudioSource _asBGM;

    void Awake()
    {
        _asSE = this.gameObject.AddComponent<AudioSource>();
        _asBGM = this.gameObject.AddComponent<AudioSource>();
    }

    public void PlaySE(string name, float volume = 1.0f)
    {
        if (BGMRack.AudioClips.TryGetValue(name, out AudioClip ac))
        {
            _asSE.volume = volume;
            _asSE.clip = ac;
            _asSE.Play();
        }
        else
        {
            Debug.LogWarning("name:" + name + "�̉��y��������Ȃ��������߁APlayBGM�̖��߂��ʂ�܂���ł���");
        }
    }

    public void PlayBGM(string name, float volume = 1.0f, bool loop = true)
    {
        if(BGMRack.AudioClips.TryGetValue(name,out AudioClip ac))
        {
            _asBGM.volume = volume;
            _asBGM.loop = loop;
            _asBGM.clip = ac;
            _asBGM.Play();
        }
        else
        {
            Debug.LogWarning("name:" + name + "�̉��y��������Ȃ��������߁APlayBGM�̖��߂��ʂ�܂���ł���");
        }
    }
}
