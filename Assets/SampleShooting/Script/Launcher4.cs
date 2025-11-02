using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher4 : MonoBehaviour
{
    float timeCount = 0; // 経過時間

    [SerializeField] GameObject shotBullet; // 発射する弾

    void Start()
    {

    }

    void Update()
    {
        // 前フレームからの時間の差を加算
        timeCount += Time.deltaTime;

        if (timeCount > 0.05f)
        {
            timeCount = 0; // 再発射のために時間をリセット

            GameObject createObject = Instantiate(shotBullet, transform.position + new Vector3(Mathf.Cos(-90 * Mathf.Deg2Rad), 0, Mathf.Sin(-90 * Mathf.Deg2Rad)), Quaternion.identity);
            Bullet bulletScript = createObject.GetComponent<Bullet>();
            bulletScript.Init(Random.Range(-180,181), 8);

        }
    }

}
