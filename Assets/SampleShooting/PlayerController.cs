using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float playerSpeed = 0.05f;  // プレイヤー速度の変数
    [SerializeField]float HP = 3;
    [SerializeField] GameObject []Heart;
    [SerializeField]Sprite []Playe_Sprite;//Playerのスプライト
    [SerializeField] GameObject playerBullet;//Playerの弾丸Object

    void Start()
    {
        Application.targetFrameRate = 60;   // フレームレートを60fpsで固定
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))    // Wキーを押している間
        {
            transform.Translate(0, playerSpeed, 0);     // Y座標をプラス側(上)に進む
            GetComponent<SpriteRenderer>().sprite = Playe_Sprite[0];//前用spriteに変更
        }
        if (Input.GetKey(KeyCode.A))    // Aキーを押している間
        {
            transform.Translate(-playerSpeed, 0, 0);    // X座標をマイナス側(左)に進む
            GetComponent<SpriteRenderer>().sprite = Playe_Sprite[1];//左用spriteに変更
        }
        if (Input.GetKey(KeyCode.S))    // Sキーを押している間
        {
            transform.Translate(0, -playerSpeed, 0);    // Y座標をマイナス側(下)に進む
            GetComponent<SpriteRenderer>().sprite = Playe_Sprite[0];//後ろ用spriteに変更
        }
        if (Input.GetKey(KeyCode.D))    // Dキーを押している間
        {
            transform.Translate(playerSpeed, 0, 0);     // X座標をプラス側(右)に進む
            GetComponent<SpriteRenderer>().sprite = Playe_Sprite[2];//右用spriteに変更
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(playerBullet, transform.position, Quaternion.identity);

        }
        if (HP == 3)
        {
            Heart[0].SetActive(true);
            Heart[1].SetActive(true);
            Heart[2].SetActive(true);
        }
        else if(HP == 2)
        {
            Heart[0].SetActive(true);
            Heart[1].SetActive(true);
            Heart[2].SetActive(false);
        }
        else if (HP == 1)
        {
            Heart[0].SetActive(true);
            Heart[1].SetActive(false);
            Heart[2].SetActive(false);
        }
        else
        {
            Heart[0].SetActive(false);
            Heart[1].SetActive(false);
            Heart[2].SetActive(false);
            Destroy(gameObject);
        }
    }
    //プレイヤーの当たり判定に当たった時の処理
    void OnCollisionEnter2D(Collision2D collision)
    {
        //タグで絞っている//
        if (collision.gameObject.tag == "Bullet")
        {
            HP -= 1;
            Destroy(collision.gameObject);
        }
    }
  
}