using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject playerBullet; // GameObject型の変数を宣言する

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))   // Enterキーを押した場合
        {
            GameObject cloneObject = Instantiate(playerBullet, this.transform.position, Quaternion.identity);  // 弾を表示させて座標を移動させる処理
            cloneObject.name = "PlayerBullet";  // 名前を変更する処理
        }
    }
}
