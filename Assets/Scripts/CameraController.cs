using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // プレイヤーオブジェクトを格納するための変数
    GameObject playerObj;

    // プレイヤーのPlayerControllerコンポーネントを格納するための変数
    PlayerController player;

    // プレイヤーオブジェクトのTransformを格納するための変数
    Transform playerTransform;

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

    //=== カメラ追従処理 ===
    void MoveCamera()
    {
        // カメラの位置をプレイヤーのX座標に追従させる（Y軸とZ軸はそのまま）
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
