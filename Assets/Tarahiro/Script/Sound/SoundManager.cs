using System.Collections;
using System.Collections.Generic;
using Tarahiro.Sound;
using Tarahiro.MasterData;
using UnityEngine;
using UnityEngine.Audio;
using Tarahiro;


/// <summary>
/// サウンド周りを管理するクラス
/// </summary>
public class SoundManager
{
    private const string bgmString = "Sound/BGM/";
    private const string seString = "Sound/SE/";



    
/// <summary>
/// とりあえずこの2つを使えればOK
/// </summary>
    public static GameObject PlaySE(string seLabel, MixerLabel MixerName = MixerLabel.EventSE, bool IsLoop = false)
    {
        return SoundMgr.Instance.dummyInstantiate(Resources.Load<GameObject>("SoundManager/" + MixerDicionary[MixerName] + "Source"), Resources.Load<AudioClip>(SoundMgr.Instance.seMasterDataProvider.TryGetFromId(seLabel).GetMaster().SePath), IsLoop);
    }

    public static GameObject PlaySEWithChangePitch(string seLabel, MixerLabel MixerName = MixerLabel.EventSE, bool IsLoop = false, float ChangePitch = SoundMgr.changePitch)
    {

        return SoundMgr.Instance.dummyInstantiateWithChangePitch(Resources.Load<GameObject>("SoundManager/" + MixerDicionary[MixerName] + "Source"), Resources.Load<AudioClip>(SoundMgr.Instance.seMasterDataProvider.TryGetFromId(seLabel).GetMaster().SePath), IsLoop,ChangePitch);

    }

    public static void PlayBGM(string BGMName,int channelId = 0, bool IsLoop = true)
    {
        SoundMgr.Instance.PlayBGM(Resources.Load<AudioClip>(bgmString + BGMName),channelId, IsLoop);
    }


    public static void SetVolumeLevel(MixerExposedParameter mixerExposedParameter, int volumeLevel)
    {
        SoundMgr.Instance.SetVolume(mixerExposedParameter, volumeLevel);
    }

    public static int VolumeLevel(MixerExposedParameter mixerExposedParameter)
    {
        return SoundMgr.Instance.VolumeLevel(mixerExposedParameter);
    }

    public static void PauseBGM()
    {
        SoundMgr.Instance.PauseBGM();
    }

    public static void RestartBGM()
    {
        SoundMgr.Instance.RestartBGM();
    }

    public static bool IsStopping
    {
        get
        {
            return SoundMgr.Instance.IsStoppingBGM();
        }
    }

    public static void CompressOrDecompressVolume(MixerExposedParameter mixerExposedParameter, bool IsCompress, float changeTime = SoundMgr.longChangeTime)
    {
        SoundMgr.Instance.CompressOrDecompressVolume(mixerExposedParameter, IsCompress, changeTime);
    }
    
    public static void SetOffsetDecibel(MixerExposedParameter mixerExposedParameter, float t_setOffsetDecibel, float changeTime = SoundMgr.longChangeTime)
    {
        SoundMgr.Instance.SetOffsetDecibel(mixerExposedParameter, t_setOffsetDecibel, changeTime);
    }

    public static void StopBGM(int channelId, float changeTime = SoundMgr.longChangeTime)
    {
        SoundMgr.Instance.StopBGM(changeTime, channelId);
    }

    public static void Mute(float changeTime, MixerExposedParameter mixerLabelEnum)
    {
        SoundMgr.Instance.Mute(mixerLabelEnum, true, changeTime);
    }

    public static GameObject PlaySEWithLoop(string seLabel, MixerLabel MixerName = MixerLabel.EventSE)
    {
        return SoundMgr.Instance.dummyInstantiateLoopSE(Resources.Load<GameObject>("SoundManager/" + MixerDicionary[MixerName] + "Source"), Resources.Load<AudioClip>(SoundMgr.Instance.seMasterDataProvider.TryGetFromId(seLabel).GetMaster().SePath));
    }

    public static GameObject PlayRefleshSE(string seLabel, MixerLabel MixerName = MixerLabel.EventSE, bool IsLoop = false)
    {
        return SoundMgr.Instance.dummyInstantiateRefleshSE(Resources.Load<GameObject>("SoundManager/" + MixerDicionary[MixerName] + "Source"), Resources.Load<AudioClip>(SoundMgr.Instance.seMasterDataProvider.TryGetFromId(seLabel).GetMaster().SePath), IsLoop);
    }


    public static void PlayInterruptedBGM(int channelId)
    {
        SoundMgr.Instance.PlayInterruptedBGM(channelId);
    }

    public static void ResetInterruptState()
    {
        SoundMgr.Instance.ResetInterruptState();
    }

    public static bool IsBGMInterrupted()
    {
        return SoundMgr.Instance.isInterrupted;
    }


    public static ResourceRequest PreloadBGM(string BGMName)
    {
        if (Application.isEditor && !System.IO.File.Exists("Assets/Resources/" + bgmString + BGMName + ".wav"))
        {
            Debug.LogError("Audioファイル：" + BGMName + ".wav が存在しません");
            return null;
        }
        else
        {
            return Resources.LoadAsync<AudioClip>(bgmString + BGMName);
        }
    }

    public static void PlayBGM(AudioClip audioClip, int channelId, bool IsLoop = true)
    {
        SoundMgr.Instance.PlayBGM(audioClip,channelId, IsLoop);
    }

    public static GameObject PlayBGMObj(string BGMName, bool IsLoop = false)
    {
        return SoundMgr.Instance.dummyInstantiateBGM(Resources.Load<GameObject>("SoundManager/BGMSource"), Resources.Load<AudioClip>(bgmString + BGMName), IsLoop);
    }

    public static AudioSource BGMSource()
    {
        return SoundMgr.Instance.BGMSource;
    }

    public static ResourceRequest BGMResource(string str)
    {
        return Resources.LoadAsync<AudioClip>("Sound/BGM/" + str);
    }


    //列挙型はこの辺に
    public enum SELabel
    {
        Enter, //決定
        Cancel, //キャンセル
        Cursor, //カーソル移動
        FootWalk,
        Text,

    }

    public enum MixerLabel
    {
        EventSE,
        EnvironmentalSE,
        BattleCommandSE,
        BFNormalSE,
        BFSpecialSE
    }

    public static Dictionary<MixerLabel, string> MixerDicionary = new Dictionary<MixerLabel, string>()
    {
        {MixerLabel.EventSE, "EventSE" },
        {MixerLabel.EnvironmentalSE, "EnvironmentalSE" },
        {MixerLabel.BattleCommandSE, "BattleCommandSE" },
        {MixerLabel.BFNormalSE,"BFNormalSE" },
        {MixerLabel.BFSpecialSE,"BFSpecialSE" }
    };


    public static void StopLoopSE()
    {
        SoundMgr.Instance.StopLoopSE();
    }


    public static void StopRefleshSE()
    {
        SoundMgr.Instance.StopRefleshSE();
    }


    public enum MixerExposedParameter
    {
        BGM,
        BGMSub,
        SE,
        EnvironmentalSE,
        BattleSE
    }

    public static Dictionary<MixerExposedParameter, string> MixerExposedParameterNameDictionary = new Dictionary<MixerExposedParameter, string>()
    {
            {MixerExposedParameter.BGM, "VolumeOfBGM" },
            {MixerExposedParameter.BGMSub, "VolumeOfBGMSub" },
            {MixerExposedParameter.SE, "VolumeOfSE" },
            {MixerExposedParameter.EnvironmentalSE, "VolumeOfEnvironmentalSE" },
            {MixerExposedParameter.BattleSE, "VolumeOfBattleSE" }
    };

    public static void PauseLoopSE()
    {
        SoundMgr.Instance.PauseLoopSE();
    }

    public static void RestartLoopSE()
    {
        SoundMgr.Instance.RestartLoopSE();
    }

    public static void StopSoloLoopSE(AudioSource audioSource)
    {
        SoundMgr.Instance.StopSoloLoopSE(audioSource);
    }

    private class SoundMgr : SingletonMonoBehaviour<SoundMgr>
    {
        public const float minimumDecibel = -80f;
        public static readonly float[] initialDecibel = new float[5]{ -10, 0, -5,-5, 0 };

        //設定数
        public const float shortChangeTime = .3f;
        public const float longChangeTime = 1f;
        public const float correctAbsDecibel = 15f;
        public const float smallNumber = 0.00001f;
        public const float changePitch = .3f;

        public ISeMasterDataProvider seMasterDataProvider;

        protected override void Awake()
        {
            base.Awake();
            audioListener = gameObject.AddComponent<AudioListener>();
            audioSource = Instantiate(Resources.Load<GameObject>("SoundManager/BGMSource"), transform).GetComponent<AudioSource>();
            audioSourceSub = Instantiate(Resources.Load<GameObject>("SoundManager/BGMSubSource"), transform).GetComponent<AudioSource>();

            for (int i = 0; i < System.Enum.GetNames(typeof(MixerExposedParameter)).Length; i++)
            {
                mixerVolumeClass[i] = Instantiate(Resources.Load<MixerVolumeClass>("SoundManager/MixerVolumeClass/MixerVolumeClass" + i), transform);
            }

            //VolumeLevel初期化
            for (int i = 0; i < System.Enum.GetNames(typeof(MixerExposedParameter)).Length; i++)
            {
                SetVolumeLevel((MixerExposedParameter)i, MixerVolumeClass.INITIAL_LEVEL);
            }

            //SeDictionaryロード
            seMasterDataProvider = new SeMasterDataProvider();
        }

        private AudioListener audioListener;
        private AudioSource audioSource;
        public AudioSource BGMSource
        {
            get
            {
                return audioSource;
            }
        }

        private AudioSource audioSourceSub;
        public AudioSource BgmSourceSub
        {
            get
            {
                return audioSourceSub;
            }

        }


        private List<GameObject> loopSEList = new List<GameObject>();
        private List<GameObject> refleshSEList = new List<GameObject>();
        static MixerVolumeClass[] mixerVolumeClass = new MixerVolumeClass[System.Enum.GetNames(typeof(MixerExposedParameter)).Length];
        static bool[] isCompressedVolume = new bool[System.Enum.GetNames(typeof(MixerExposedParameter)).Length];
        static int[] volumeLevel = new int[System.Enum.GetNames(typeof(MixerExposedParameter)).Length];

        AudioClip interruptedAudioClip;
        float interruptedBGMTime;
        public bool isInterrupted { get; private set; }


        public void PlayBGM(AudioClip audioClip,int channelId, bool IsLoop = true)
        {
            int mixerExposedParameterIndex = channelId;
            ExecuteToPlayBGM(audioClip,channelId,  IsLoop);
        }

        public void ResetInterruptState()
        {
            isInterrupted = false;
            interruptedAudioClip = null;
            interruptedBGMTime = 0f;
        }

        public void PlayInterruptedBGM(int channelId, float volumeChangeTime = longChangeTime)
        {
            isInterrupted = false;
            int mixerExposedParameterIndex = channelId;
            mixerVolumeClass[mixerExposedParameterIndex].Mute(true,0);
            mixerVolumeClass[mixerExposedParameterIndex].Mute(false);

            ExecuteToPlayBGM(interruptedAudioClip,channelId, true);
            audioSource.time = interruptedBGMTime;
        }

        void ExecuteToPlayBGM(AudioClip audioClip,int channelId, bool IsLoop) {

            AudioSource t_audioSource;

            if (channelId == 0)
            {
                t_audioSource = audioSource;
            }
            else
            {
                t_audioSource = audioSourceSub;
            }
            t_audioSource.clip = audioClip;
            t_audioSource.loop = IsLoop;
            t_audioSource.time = 0;
            t_audioSource.Play();
            Mute((MixerExposedParameter)channelId, false, 0);
            CompressOrDecompressVolume((MixerExposedParameter)channelId, false, 0);
        }

        public GameObject dummyInstantiateWithChangePitch(GameObject obj, AudioClip audioClip, bool Isloop, float changePitchRatio)
        {
            GameObject g = dummyInstantiate(obj, audioClip, Isloop);
            AudioSource audioSource = g.GetComponent<AudioSource>();
            audioSource.pitch = Random.Range(audioSource.pitch * (1 - changePitchRatio), audioSource.pitch * (1 + changePitchRatio));
            return g;
        
        }

        public GameObject dummyInstantiate(GameObject obj,AudioClip audioClip,bool Isloop)
        {
            SESource seSource = Instantiate(obj, transform).GetComponent<SESource>();

            Log.DebugAssert(audioClip != null);
            seSource.clip = audioClip;
            seSource.loop = Isloop;
            seSource.Play();
            return seSource.gameObject;
        }

        public GameObject dummyInstantiateBGM(GameObject obj, AudioClip audioClip, bool Isloop)
        {
            AudioSource seSource = Instantiate(obj, transform).GetComponent<AudioSource>();

            Log.DebugAssert(audioClip != null);
            seSource.clip = audioClip;
            seSource.loop = Isloop;
            seSource.Play();
            return seSource.gameObject;
        }

        public GameObject dummyInstantiateLoopSE(GameObject obj, AudioClip audioClip)
        {
            return dummyInstantiateWithList(obj, audioClip, true, loopSEList);
        }

        public GameObject dummyInstantiateRefleshSE(GameObject obj, AudioClip audioClip,bool IsLoop)
        {
            return dummyInstantiateWithList(obj, audioClip, IsLoop, refleshSEList);
        }

        public GameObject dummyInstantiateWithList(GameObject obj, AudioClip audioClip, bool IsLoop, List<GameObject> SoundObjectList)
        {
            SoundObjectList.Add(dummyInstantiate(obj, audioClip, IsLoop));
            return SoundObjectList[SoundObjectList.Count - 1];
        }


         void _StopBGM()
        {
            audioSource.Stop();
        }

        public void RefleshLoopSEList()
        {
            for (int i = loopSEList.Count - 1; i >= 0; i--)
            {
                if (loopSEList[i] == null)
                {
                    loopSEList.RemoveAt(i);
                }
            }
        }

        public void StopLoopSE()
        {
            for(int i = 0;i < loopSEList.Count; i++)
            {
                if (loopSEList[i] != null)
                {
                    loopSEList[i].GetComponent<AudioSource>().loop = false;
                }
            }
            loopSEList = new List<GameObject>();
        }

        public void StopRefleshSE()
        {
            for(int i = 0; i < refleshSEList.Count; i++)
            {
                if(refleshSEList[i] != null)
                {
                    Destroy(refleshSEList[i]);
                }
            }
            refleshSEList = new List<GameObject>();
        }

        public bool IsStoppingBGM()
        {
            return mixerVolumeClass[(int)MixerExposedParameter.BGM].IsChanging && mixerVolumeClass[(int)MixerExposedParameter.BGM].IsMute;
        }

        public void StopBGM(float changeTime, int channelId)
        {
            mixerVolumeClass[channelId].Mute(true, changeTime);
        }

        public void PauseBGM()
        {
            if(BGMSource != null)
            {
                BGMSource.Pause();
            }
        }

        public void RestartBGM()
        {
            if(BGMSource != null)
            {
                if (!BGMSource.isPlaying)
                {
                    BGMSource.Play();
                }
                   
            }
        }

        public void CompressOrDecompressVolume(MixerExposedParameter mep, bool IsCompress, float changeTime = longChangeTime)
        {
            int mepIndex = (int)mep;
            mixerVolumeClass[mepIndex].Compress(IsCompress, changeTime);
        }


        public void SetOffsetDecibel(MixerExposedParameter mep, float offsetDecibel, float changeTime = longChangeTime)
        {
            int mepIndex = (int)mep;
            mixerVolumeClass[mepIndex].SetOffsetDecibel(offsetDecibel, changeTime);
        }

        public void Mute(MixerExposedParameter mep, bool IsMute, float changeTime = longChangeTime)
        {
            int mepIndex = (int)mep;
            mixerVolumeClass[mepIndex].Mute(IsMute, changeTime);
        }

        public void SetVolume(MixerExposedParameter mep, int _volumeLevel)
        {
            int mepIndex = (int)mep;
            mixerVolumeClass[mepIndex].SetVolumeLevel(_volumeLevel);
        }

        public int VolumeLevel(MixerExposedParameter mep)
        {
            int mepIndex = (int)mep;
            return mixerVolumeClass[mepIndex].volumeLevel;
        }

        public void PauseLoopSE()
        {
            for(int i = 0; i < loopSEList.Count; i++)
            {
                if (loopSEList[i] != null)
                {
                    loopSEList[i].GetComponent<AudioSource>().loop = false;
                }
            }
        }

        public void RestartLoopSE()
        {
            for (int i = 0; i < loopSEList.Count; i++)
            {
                if (loopSEList[i] != null)
                {
                    loopSEList[i].GetComponent<AudioSource>().loop = true;
                }
            }
        }

        public void StopSoloLoopSE(AudioSource audioSource)
        {
            for(int i = 0; i < loopSEList.Count; i++)
            {
                if(loopSEList[i] != null)
                {
                    if(audioSource == loopSEList[i].GetComponent<AudioSource>())
                    {
                       // loopSEList[i] = null;
                    }
                }
            }
            audioSource.loop = false;
        }
    

    }
}
