using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSceneManager : MonoBehaviour
{
    AudioScript audioScript;
    [SerializeField] AudioClip ClearSE;

    // Start is called before the first frame update
    void Start()
    {
        audioScript = GameObject.Find("BGM").GetComponent<AudioScript>();
        audioScript.OneShot_Play(ClearSE);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
