using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
/*
using Csq;
using Csq.Asset;
*/

public class MixerVolumeClass : MonoBehaviour
{

    const float DEFAULT_CHANGE_TIME = 0f;
    public const int MAX_LEVEL = 100;
    public const int INITIAL_LEVEL = 70;
    const float COMPRESS_DECIBEL = 15f;
    const float minimumDecibel = -80f;

    [SerializeField] AudioMixer _audioMixer;
    [SerializeField] string _exposedParameterName;
    [SerializeField] float defaultDecibel;
    [SerializeField] float level1Decibel;

    //フラグ系
    public bool IsChanging { get; private set; } = false;
    public bool IsCompressed { get; private set; } = false;
    public bool IsMute { get; private set; } = false;
    public int volumeLevel { get; private set; } = INITIAL_LEVEL;
    public float offsetDecibel
    {
        get;private set;
    }

    float _initialDecibel { get; set; }
    float _finalDecibel;
    float _currentDecibel;
    float _currentTime;
    float _changeTime;
    public SoundManager.MixerExposedParameter mixerLabelEnum { get; set; }


    public void SetVolumeLevel(int volumeLevel, float changeTime = DEFAULT_CHANGE_TIME)
    {
        this.volumeLevel = volumeLevel;
        SetVolume(CalculateVolume(), changeTime);
    }

    public void Compress(bool IsCompress, float changeTime = DEFAULT_CHANGE_TIME)
    {
        IsCompressed = IsCompress;
        SetVolume(CalculateVolume(), changeTime);
    }

    public void SetOffsetDecibel(float t_offsetDecibel, float changeTime = DEFAULT_CHANGE_TIME)
    {
        offsetDecibel = t_offsetDecibel;
        SetVolume(CalculateVolume(), changeTime);
    }

    public void Mute(bool IsMute, float changeTime = DEFAULT_CHANGE_TIME)
    {
        this.IsMute = IsMute;
        SetVolume(CalculateVolume(), changeTime);
    }

    void SetVolume(float _fdecibel, float changeTime)
    {
        _finalDecibel = _fdecibel;
        _currentTime = 0;
        _changeTime = changeTime;
        _initialDecibel = _currentDecibel;
        IsChanging = true;
        ReflectVolume();
    }

    void Update()
    {
        if (IsChanging)
        {

            _currentTime += Time.deltaTime;
            ReflectVolume();
        }
    }

    public void ReflectCurrentVolume()
    {
        ReflectVolume();
    }

    void ReflectVolume()
    {
        if (_currentTime < _changeTime)
        {
            _currentDecibel = _initialDecibel + (_finalDecibel - _initialDecibel) * Const.AccelDecel(_currentTime / _changeTime);
        }
        else
        {
            _currentDecibel = _finalDecibel;
            IsChanging = false;
        }
        _audioMixer.SetFloat(_exposedParameterName, _currentDecibel);
    }

    float CalculateVolume()
    {
        if (IsMute)
        {
            return minimumDecibel;
        }
        else
        {
            float t_decibel = DecibelFromLevel(volumeLevel) + offsetDecibel;

            if (IsCompressed)
            {
                t_decibel -= COMPRESS_DECIBEL;
                if (t_decibel < minimumDecibel)
                {
                    return minimumDecibel;
                }
                else
                {
                    return t_decibel;
                }
            }
            else
            {
                return t_decibel;
            }
        }
    }

    float DecibelFromLevel(int level)
    {
        float rate = ((float)level) / (MAX_LEVEL - 1);

        if (rate > 0.0001f)
        {
            return 20.0f * Mathf.Log10(rate) / Mathf.Log10(10f);
        }
        else
        {
            return minimumDecibel;
        }
    }


}
