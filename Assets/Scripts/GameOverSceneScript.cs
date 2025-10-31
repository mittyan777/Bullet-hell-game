using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSceneScript : MonoBehaviour
{
    AudioScript audioScript;
    [SerializeField] AudioClip GameOverSE;

    // Start is called before the first frame update
    void Start()
    {
        audioScript = GameObject.Find("BGM").GetComponent<AudioScript>();
        audioScript.Set_FadeoutVolume_Function();
        audioScript.OneShot_Play(GameOverSE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
