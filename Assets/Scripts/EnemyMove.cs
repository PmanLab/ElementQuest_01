using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    //=== 変数宣言 ===
    [SerializeField, Header("敵の移動速度")] private float fSpeed = 2.0f;
    [SerializeField, Header("敵 ジャンプ力 入力")] private float fJumpForce = 5.0f;
    [SerializeField, Header("敵 ジャンプの間隔 入力")] private float fJumpInterval = 2.0f;
    [SerializeField, Header("敵 次のジャンプの時間 入力")] private float fNextJumpTime = 0f;
    //--- 格納用インスタンス ---
    private GameObject playerObj;       // プレイヤー情報格納用
    private Rigidbody2D rb;             // Rigidbody2D情報格納用
    private EnemyState enemyState;      // 敵種類情報格納用


    //--- 検知用フラグ
    private bool bIsMove = false;      // 敵が動作フラグ
    private bool bIsGround = false;    // 地面接触フラグ

    //=== 初期化処理 ===
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerObj = GameObject.FindGameObjectWithTag("Player"); // プレイヤーを探して格納
        enemyState = gameObject.GetComponent<EnemyState>();

    }

    //=== 更新処理 ===
    private void Update()
    {
        // カメラのビューポート座標を取得
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        // 敵がカメラに映ったかどうかを判定
        if (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1 && viewportPosition.z > 0)
        {
            bIsMove = true;             // 敵行動開始  フラグON
        }
        else
        {
            bIsMove = false;
            
        }

        // 敵が動く場合の処理
        if (bIsMove)
        {
            //--- 敵 行動パターン ---
            switch (enemyState.EnemyType)
            { 
                // スライム
                case EnemyState.eEnemyType.Slime:
                    MoveTowardsPlayer();
                    if (bIsGround) { Jump(); }

                    break;
                default:
                    break;
            }
        }
        // 敵が動かなる場合の処理
        else
        {
            StopEnemy();
        }

    }

    //=== 自作メソッド ===
    //--- 敵を右方向に移動処理 ---
    void MoveEnemy()
    {
        transform.Translate(Vector2.right * fSpeed * Time.deltaTime);
    }

    void MoveTowardsPlayer()
    {
        // プレイヤーの位置に向かって移動
        Vector2 direction = (playerObj.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * fSpeed, rb.velocity.y);
    }

    void StopEnemy()
    {
        // 敵の移動を停止
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f; // 角速度もリセット
    }

    void Jump()
    {
        // 一定間隔でジャンプする
        if (Time.time > fNextJumpTime)
        {
            rb.AddForce(Vector2.up * fJumpForce, ForceMode2D.Impulse);
            fNextJumpTime = Time.time + fJumpInterval;
            bIsGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // すり抜け防止のため、地面に触れているかどうかを判定
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Scaffold") ||
            collision.gameObject.CompareTag("Wall"))
        {
            bIsGround = true;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}
