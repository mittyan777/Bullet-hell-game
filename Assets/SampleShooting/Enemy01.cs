using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Enemy01 : MonoBehaviour
{
    [SerializeField] GameSceneManager gameSceneManager;

    int hp = 50; // HPを管理する変数を宣言
    [SerializeField] int Section2HP;
    [SerializeField] int Section3HP;
    [SerializeField]Slider hpSlider;
    int SectionNum = 1;

    [Space(2)][Header("弾の種類")]
    [SerializeField] GameObject BulletType1;
    [SerializeField] GameObject BulletType2;
    [SerializeField] GameObject BulletType3;

    [SerializeField] float movespeed = 0.25f;
    [SerializeField] Transform movepos1;
    [SerializeField] Transform movepos2;
    private float t = 0f;
    private bool forward = true;

    void Start()
    {
        BulletType1.SetActive(true);
        BulletType2.SetActive(false);
        BulletType3.SetActive(false);
    }

    void Update()
    {
        hpSlider.value = hp;

        if(SectionNum is 3)
        {
            // 進行方向に応じて t を増減
            if (forward)
                t += movespeed * Time.deltaTime;
            else
                t -= movespeed * Time.deltaTime;

            // 0～1の範囲に制限
            t = Mathf.Clamp01(t);

            // 実際の移動
            transform.position = Vector2.Lerp(movepos1.position, movepos2.position, t);

            // 端に到達したら方向反転
            if (t >= 1f)
                forward = false;
            else if (t <= 0f)
                forward = true;
        }

        if (hp <= Section3HP && SectionNum is 2)
        {
            BulletType2.SetActive(false);
            BulletType3.SetActive(true);
            SectionNum = 3;
        }
        else if (hp <= Section2HP && SectionNum is 1)
        { 
            BulletType1.SetActive(false);
            BulletType2.SetActive(true);
            SectionNum = 2;
        }
    }
    void OnTriggerEnter2D(Collider2D collision) // 当たり判定のあるオブジェクトと当たった場合
    {
        if (collision.gameObject.name == "playerBullet(Clone)")   // 当たったオブジェクトがプレイヤーの弾の場合
        {
            hp--;   // HPを1減らす処理

            if (hp <= 0)    // HPが0になった場合
            {
                gameSceneManager.Set_StageBossDead();
                this.gameObject.SetActive(false);    // 敵オブジェクトを非表示にする
            }
        }
    }
}