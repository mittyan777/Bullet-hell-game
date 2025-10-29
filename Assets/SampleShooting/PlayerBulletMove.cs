using UnityEngine;

public class PlayerBulletMove : MonoBehaviour
{
    float bulletSpeed = 0.2f;   // 弾のスピードを決める変数

    void Update()
    {
        transform.Translate(0, bulletSpeed, 0); // Y座標をプラスに動く
        if (transform.position.y > 5)   // Y座標が5より大きい場合
        {
            Destroy(gameObject);    // オブジェクトを破壊する
        }
    }

    void OnTriggerEnter2D(Collider2D collision) // 当たり判定のあるオブジェクトと当たった場合
    {
        if (collision.gameObject.tag == "Enemy")    // 当たったオブジェクトがEnemyの場合
        {
            Destroy(gameObject);    // オブジェクトを破壊する
        }
    }
}