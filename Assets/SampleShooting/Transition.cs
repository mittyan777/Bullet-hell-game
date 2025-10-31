using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Transition : MonoBehaviour
{
    public string transPress;   //Press Any Key で遷移  
    public string transTime;    //時間経過で遷移
    public int timeOver;        //遷移する時間
    float elapsedTime;
    bool Is_Loading;

    public AudioClip SE_Sound;//効果音
    AudioSource audioSource;
    public Text score_object = null;    //UIで点数表示

    void Start()
    {
        elapsedTime = 0;
        audioSource = GetComponent<AudioSource>();
        //UIで点数表示
        //Text score_text = score_object.GetComponent<Text>();
        //score_text.text = "SCORE:" + PlayerMove.getPoint;
    }

    void Update()
    {
        if (Input.anyKeyDown && !Is_Loading)      //Press Any Key
        {
            Is_Loading = true;
            audioSource.PlayOneShot(SE_Sound);
            StartCoroutine(SceneLoad(transPress));
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime > timeOver)
        {
            //SceneManager.LoadScene(transTime);
        }
    }

    IEnumerator SceneLoad(string sceneName)
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneName);
    }

    public bool Get_IsLoading() { return Is_Loading; }
}
