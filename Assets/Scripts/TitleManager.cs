using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TitleManager : MonoBehaviour
{
    [Header("素材ファイル")]
    public AudioClip BGM_File;//BGM
    AudioScript audioScript;

    // Start is called before the first frame update
    void Start()
    {
        audioScript = GameObject.Find("BGM").GetComponent<AudioScript>();
        audioScript.Change_PlayAudio_with_VolumeDown(BGM_File);
    }

    // Update is called once per frame
    void Update()
    {
        if(audioScript.Return_AudioPlaying() is false)
        {
            audioScript.Change_PlayAudio(BGM_File);
        }
    }
}
