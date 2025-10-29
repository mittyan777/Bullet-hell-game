using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float playerSpeed = 0.05f;  // プレイヤー速度の変数

    void Start()
    {
        Application.targetFrameRate = 60;   // フレームレートを60fpsで固定
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))    // Wキーを押している間
        {
            transform.Translate(0, playerSpeed, 0);     // Y座標をプラス側(上)に進む
        }
        if (Input.GetKey(KeyCode.A))    // Aキーを押している間
        {
            transform.Translate(-playerSpeed, 0, 0);    // X座標をマイナス側(左)に進む
        }
        if (Input.GetKey(KeyCode.S))    // Sキーを押している間
        {
            transform.Translate(0, -playerSpeed, 0);    // Y座標をマイナス側(下)に進む
        }
        if (Input.GetKey(KeyCode.D))    // Dキーを押している間
        {
            transform.Translate(playerSpeed, 0, 0);     // X座標をプラス側(右)に進む
            void OnTriggerEnter2D(Collider2D collision) // 他のオブジェクトとの当たり判定の処理
            {
                if (collision.gameObject.name == "EnemyBullet" ||   // 敵の弾に当たった場合
                    collision.gameObject.tag == "Enemy")            // 敵のオブジェクトに触れた場合
                {
                    this.gameObject.SetActive(false);   // オブジェクトを消去する
                }
            }
        }
    }
    }