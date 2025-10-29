using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public string transPress;   //Press Any Key で遷移  
    public string transTime;    //時間経過で遷移
    public int timeOver;        //遷移する時間
    float elapsedTime;

    public Text score_object = null;    //UIで点数表示

    void Start()
    {
        elapsedTime = 0;

        //UIで点数表示
        //Text score_text = score_object.GetComponent<Text>();
        //score_text.text = "SCORE:" + PlayerMove.getPoint;
    }

    void Update()
    {
        if (Input.anyKeyDown)      //Press Any Key
        {
            SceneManager.LoadScene(transPress);
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime > timeOver)
        {
            SceneManager.LoadScene(transTime);
        }
    }
}
