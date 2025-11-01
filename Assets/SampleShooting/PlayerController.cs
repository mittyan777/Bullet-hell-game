using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameSceneManager gameSceneManager;
    Rigidbody2D rb;
    float playerSpeed = 5f;  // プレイヤー速度の変数
    const float noHitTime = 1.0f;//被弾後の無敵時間
    float noHit_CountTimer = 0;
    bool Is_noHitTime;

    [SerializeField] float HP = 3;
    [SerializeField] GameObject[] Heart;
    [SerializeField] Sprite[] Playe_Sprite;//Playerのスプライト
    [SerializeField] GameObject playerBullet;//Playerの弾丸Object

    [Header("音関係")]
    [SerializeField] AudioClip ShotSound;//弾発射音
    [SerializeField] AudioClip DamageSound;//被弾音
    AudioSource playerSource;

    void Start()
    {
        Application.targetFrameRate = 60;   // フレームレートを60fpsで固定
        playerSource= gameObject.AddComponent<AudioSource>();
        rb= GetComponent<Rigidbody2D>();
        noHit_CountTimer = noHitTime;
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.W))    // Wキーを押している間
        //{
        //    transform.Translate(0, playerSpeed, 0);     // Y座標をプラス側(上)に進む
        //    GetComponent<SpriteRenderer>().sprite = Playe_Sprite[0];//前用spriteに変更
        //}
        //if (Input.GetKey(KeyCode.A))    // Aキーを押している間
        //{
        //    transform.Translate(-playerSpeed, 0, 0);    // X座標をマイナス側(左)に進む
        //    GetComponent<SpriteRenderer>().sprite = Playe_Sprite[1];//左用spriteに変更
        //}
        //if (Input.GetKey(KeyCode.S))    // Sキーを押している間
        //{
        //    transform.Translate(0, -playerSpeed, 0);    // Y座標をマイナス側(下)に進む
        //    GetComponent<SpriteRenderer>().sprite = Playe_Sprite[0];//後ろ用spriteに変更
        //}
        //if (Input.GetKey(KeyCode.D))    // Dキーを押している間
        //{
        //    transform.Translate(playerSpeed, 0, 0);     // X座標をプラス側(右)に進む
        //    GetComponent<SpriteRenderer>().sprite = Playe_Sprite[2];//右用spriteに変更
        //}
        //弾発射
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Instantiate(playerBullet, transform.position, Quaternion.identity);
            playerSource.PlayOneShot(ShotSound);
        }

        //移動
        Vector2 move = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            move.y += 1;
            GetComponent<SpriteRenderer>().sprite = Playe_Sprite[0];
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.y -= 1;
            GetComponent<SpriteRenderer>().sprite = Playe_Sprite[0];
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.x -= 1;
            GetComponent<SpriteRenderer>().sprite = Playe_Sprite[1];
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.x += 1;
            GetComponent<SpriteRenderer>().sprite = Playe_Sprite[2];
        }
        if (move == Vector2.zero)
        {
            GetComponent<SpriteRenderer>().sprite = Playe_Sprite[0];
        }

        move = move.normalized * playerSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        if (HP == 3)
        {
            Heart[0].SetActive(true);
            Heart[1].SetActive(true);
            Heart[2].SetActive(true);
        }
        else if (HP == 2)
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
            DestroyObject();
        }
        
        if(Is_noHitTime is true)
        {
            noHit_CountTimer-= Time.deltaTime;
            if(noHit_CountTimer <= 0) { 
            Is_noHitTime = false;
                noHit_CountTimer = noHitTime;
            }
        }
    }

    //プレイヤーの当たり判定に当たった時の処理
    void OnCollisionEnter2D(Collision2D collision)
    {
        bool StageCleared = gameSceneManager.Is_StageCleared();
        //タグで絞っている//
        if (collision.gameObject.tag == "Bullet" && !Is_noHitTime && !StageCleared) 
        {
            playerSource.PlayOneShot(DamageSound,0.1f);
            HP -= 1;
            Is_noHitTime = true;
            Destroy(collision.gameObject);
        }
    }

    void DestroyObject()
    {
        gameSceneManager.Set_PlayerDead();
        Destroy(gameObject);
    }
}