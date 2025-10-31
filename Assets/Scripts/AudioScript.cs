using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class AudioScript : MonoBehaviour
{
    static private AudioSource audioSource;
    static private AudioClip NextPlay_clip;
    static bool Audio_Loaded = false;
    static float Current_Volume;
    static float Current_Pitch;
    bool Function_BGM_VolumeDown = false;
    const float Down_Value = 0.25f;

    // Start is called before the first frame update
    void Awake()
    {
        //重複防止処理
        if (Audio_Loaded == true)
        {
            Destroy(this.gameObject);
            return;
        }
        Audio_Loaded = true;
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        // 初期ボリュームを保持 or 過去値を復元
        if (Current_Volume == 0f)
        {
            Current_Volume = audioSource.volume;
        }
        else
        {
            audioSource.volume = Current_Volume;
        }
        Current_Pitch = audioSource.pitch;
    }

    void Update()
    {
        //フェードアウト処理
        if (Function_BGM_VolumeDown == true)
        {
            if (Return_AudioPlaying() == true)
            {
                Fadeout_AudioVolume();
            }
            else
            {
                Function_BGM_VolumeDown = false;
                Change_PlayAudio(NextPlay_clip);
            }
        }
    }

    //音楽再生
    void PlayAudio(AudioClip audio)
    {
        Function_BGM_VolumeDown = false;
        audioSource.Stop();
        audioSource.clip = audio;
        audioSource.loop = true;
        audioSource.Play();
    }

    //音楽をすぐに変更する
    public void Change_PlayAudio(AudioClip audio)
    {
        if (audioSource.clip == audio && audio == null) return;
        PlayAudio(audio);
        Debug.Log("Audio Changed");
    }

    //音楽をフェードアウトしてから変更する
    public void Change_PlayAudio_with_VolumeDown(AudioClip audio)
    {
        if (audioSource.clip == audio || Function_BGM_VolumeDown == true) return;
        NextPlay_clip = audio;
        Function_BGM_VolumeDown = true;
    }

    //効果音再生用
    public void OneShot_Play(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }

    //音楽の再生を停止
    public void Stop_Audio()
    {
        Function_BGM_VolumeDown = false;
        audioSource.Stop();
        Reset_AudioValue();
    }

    //パラメータを初期化
    public void Reset_AudioValue()
    {
        audioSource.volume = Current_Volume;
        audioSource.pitch = Current_Pitch;
    }
    public void Reset_AudioValue(float Vol)
    {
        Current_Volume = Vol;
        audioSource.volume = Vol;
        audioSource.pitch = Current_Pitch;
    }

    //任意のパラメータを設定（ただし、エフェクト実行中は無視）
    public void Set_AudioParameter(float Volume)
    {
        if (Function_BGM_VolumeDown == true) return;
        Current_Volume = Volume;
        audioSource.volume = Volume;
    }
    public void Set_AudioParameter(float Volume, float Pitch)
    {
        if (Function_BGM_VolumeDown == true) return;
        audioSource.volume = Volume;
        Current_Volume = Volume;
        audioSource.pitch = Pitch;
    }

    //フェードアウト処理
    public void Set_FadeoutVolume_Function()
    {
        Function_BGM_VolumeDown = true;
    }
    void Fadeout_AudioVolume()
    {
        if (audioSource.volume <= 0) return;

        audioSource.volume -= Down_Value * Time.deltaTime;
        if (audioSource.volume <= 0) { Stop_Audio(); }

    }

    void Fadeout_AudioPitch()
    {
        if (audioSource.pitch <= 0) return;

        audioSource.pitch -= Down_Value * Time.deltaTime;
        if (audioSource.pitch <= 0) { Stop_Audio(); }        
    }

    //再生中かを判定
    public bool Return_AudioPlaying() { return audioSource.isPlaying; }

    //現在の音量
    public float Get_AudioVolume()
    {
        return audioSource.volume;
    }
}
