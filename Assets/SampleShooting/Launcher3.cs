using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher3 : MonoBehaviour
{
    float timeCount = 0; // 経過時間
    [SerializeField]float shotAngle = 0; // 発射角度
    [SerializeField] bool Angle_adjustment = false;// 発射角度変更トリガー
    [SerializeField] GameObject shotBullet; // 発射する弾

    void Start()
    {
        // 何も書かない
    }

    void Update()
    {
        // 前フレームからの時間の差を加算
        timeCount += Time.deltaTime;

        // 0.1秒を超えているか
        if (timeCount > 0.3f)
        {
            timeCount = 0; // 再発射のために時間をリセット
          //shotAngleが0以上の場合-180までshotAngleをマイナスするようにしている
            if (shotAngle >= 0)
            {
                Angle_adjustment = true;


            }
            //shotAngleが-180以上の場合0までshotAngleをプラスするようにしている
            if (shotAngle <= -180)
            {
                Angle_adjustment = false;
            }

            if(Angle_adjustment == false)
            {
                shotAngle += 10;
            }
            else if(Angle_adjustment == true)
            {
                shotAngle -= 10;
            }

            // GameObjectを新たに生成する
            // 第一引数：生成するGameObject
            // 第二引数：生成する座標
            // 第三引数：生成する角度
            // 戻り値：生成したGameObject
            GameObject createObject = Instantiate(shotBullet, transform.position, Quaternion.identity);

            // 生成したGameObjectに設定されている、Bulletスクリプトを取得する
            Bullet bulletScript = createObject.GetComponent<Bullet>();

            // BulletスクリプトのInitを呼び出す
            bulletScript.Init(shotAngle, 7);
        }
    }
}