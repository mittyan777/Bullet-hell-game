using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [Header("素材ファイル")]
    public AudioClip BGM_File;//BGM
    private AudioScript audioScript;
    [SerializeField] string ClearScene;
    [SerializeField] string GameOverScene;
    [SerializeField] AudioClip Player_DeathSound;//やられた時の音

    [Header("キャラクター")]
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject StageBoss;
    bool PlayerDead;
    bool StageBossDead;

    // Start is called before the first frame update
    void Start()
    {
        audioScript = GameObject.Find("BGM").GetComponent<AudioScript>();
        audioScript.Change_PlayAudio(BGM_File);
    }

    // Update is called once per frame
    void Update()
    {
        //ステージクリア
        if(StageBossDead is true)
        {
            StartCoroutine(SceneLoad(ClearScene));
        }
        //ゲームオーバー
        if (PlayerDead is true)
        {
            StartCoroutine(SceneLoad(GameOverScene));
        }
    }

    public void Set_PlayerDead() {  
        PlayerDead = true;
        audioScript.OneShot_Play(Player_DeathSound);
    }
    public void Set_StageBossDead() { StageBossDead = true; }

    IEnumerator SceneLoad(string sceneName)
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneName);
    }
}
