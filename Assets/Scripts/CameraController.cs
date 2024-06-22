using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //--- 格納用インスタンス ---
    PlayerController player;

    //--- 変数宣言 ---
    GameObject playerObj;           // PlayerObject格納用
    Transform playerTransform;      // PlayerObjectのTransform格納用


    //=== 初期化処理 ===
    void Start()
    {
        // タグが"Player"のオブジェクトを検索して取得
        playerObj = GameObject.FindGameObjectWithTag("Player");

        // プレイヤーオブジェクトのPlayerControllerコンポーネントを取得
        player = playerObj.GetComponent<PlayerController>();

        // プレイヤーオブジェクトのTransformを取得
        playerTransform = playerObj.transform;
    }

    //=== 更新処理 ===
    void LateUpdate()
    {
        // カメラをプレイヤーに追従させる処理を呼び出し
        MoveCamera();
    }

    //=== 自作メソッド ===
    //--- カメラ追従処理 ---
    void MoveCamera()
    {
        // カメラの位置をプレイヤーのX座標に追従させる（Y軸とZ軸はそのまま）
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
