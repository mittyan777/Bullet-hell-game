using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Enemy01 : MonoBehaviour
{
    float hp = 50; // HPを管理する変数を宣言
    [SerializeField]Slider hpSlider;
    void Update()
    {
        hpSlider.value = hp;
    }
    void OnTriggerEnter2D(Collider2D collision) // 当たり判定のあるオブジェクトと当たった場合
    {
        if (collision.gameObject.name == "playerBullet(Clone)")   // 当たったオブジェクトがプレイヤーの弾の場合
        {
            hp--;   // HPを1減らす処理

            if (hp <= 0)    // HPが0になった場合
            {
                this.gameObject.SetActive(false);    // 敵オブジェクトを非表示にする
            }
        }
    }
}