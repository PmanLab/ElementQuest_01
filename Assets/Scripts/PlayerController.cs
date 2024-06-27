using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    //--- 格納用インスタンス ---
    private PlayerInputSystem playerInputSystem;
    private GameManager gameManager;

    //--- 行動用 ---
    private Vector2 inputAxis;

    //--- シリアライズ変数 ---
    [SerializeField, Header("移動スピード")] public float fWalkSpeed = 5.0f;
    [SerializeField, Header("走行スピード")] public float fRunSpeed = 10.0f;
    [SerializeField, Header("ジャンプ力")] public float fJumpForce = 10.0f;
    [SerializeField, Header("点滅時間")] public float fBlinkDuration = 1.0f;
    [SerializeField, Header("点滅間隔")] public float fBlinkInterval = 0.1f;
    [SerializeField, Header("接触時の弾き出し力")] public float fKnockbackForce = 10.0f;

    //--- リジットボディ ---
    private Rigidbody2D rb;

    //--- 検知フラグ ---
    public static bool bIsJump = false;      // ジャンプ 検知用
    public static bool bIsRun = false;       // 走り 検知用
    public static bool bIsWalk = false;      // 歩き 検知用

    private bool bIsGround = false;
    private bool bIsFacingRight = false; // プレイヤーの向きを追跡するためのフラグ

    public static bool bIsPaused = false;

    //--- 点滅処理用 ---
    private SpriteRenderer spriteRenderer;

    //=== 初期化処理 ===
    void Start()
    {
        playerInputSystem = new PlayerInputSystem();        // インスタンス情報取得
        playerInputSystem.Enable();                         // 入力受付開始
        rb = GetComponent<Rigidbody2D>();                   // リジットボディを取得
        gameManager = GameManager.Instance;                 // GameManagerを取得
        spriteRenderer = GetComponent<SpriteRenderer>();    // スプライトレンダラーを取得
        Flip();                                             // 初期状態：右向き
    }

    //=== 更新処理 ===
    void Update()
    {
        inputAxis = playerInputSystem.Player.Move.ReadValue<Vector2>();

        // リセット状態
        bIsRun = false;
        bIsWalk = false;

        //--- ポーズ画面 ---
        if (playerInputSystem.Player.Pause.triggered && !bIsPaused)
        {
            bIsPaused = true;
            gameManager.SetGameState(GameManager.eGameState.Paused);
            Debug.Log("ポーズ画面を開きました。");
        }
        else if (playerInputSystem.Player.Pause.triggered && bIsPaused)
        {
            bIsPaused = false;
            gameManager.SetGameState(GameManager.eGameState.Playing);
            Debug.Log("ポーズ画面を閉じました、ゲームに戻ります。");
        }

        //=== 非ポーズ画面時 処理 ===
        if (!bIsPaused)
        {
            //--- 左右 移動(走り移動) ---
            if (inputAxis.x < 0 && playerInputSystem.Player.Run.IsPressed())
            {
                bIsRun = true;
                MoveLeft(fRunSpeed);
                //Debug.Log("左 ダッシュ移動");
            }
            else if (inputAxis.x < 0)
            {
                bIsWalk = true;
                MoveLeft(fWalkSpeed);
                //Debug.Log("左 移動");
            }
            else if (inputAxis.x > 0 && playerInputSystem.Player.Run.IsPressed())
            {
                bIsRun = true;
                MoveRight(fRunSpeed);
                //Debug.Log("右 ダッシュ移動");
            }
            else if (inputAxis.x > 0)
            {
                bIsWalk = true;
                MoveRight(fWalkSpeed);
                //Debug.Log("右 移動");
            }
            else
            {
                // 入力がない場合、速度をゼロにする
                StopMovement();
            }

            //--- ジャンプ ---
            if (playerInputSystem.Player.Jump.triggered && bIsGround)
            {
                bIsJump = true;
                Jump();
                //Debug.Log("ジャンプしました。");
            }

            // プレイヤーの向きを更新
            UpdateFacingDirection(inputAxis.x);
        }
    }

    //=== 自作メソッド ===
    //--- 左移動 処理 ---
    void MoveLeft(float speed)
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    //--- 右移動 処理 ---
    void MoveRight(float speed)
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    //--- 停止 処理 ---
    void StopMovement()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    //--- ジャンプ 処理 ---
    void Jump()
    {
        rb.AddForce(new Vector2(0, fJumpForce), ForceMode2D.Impulse);
        bIsGround = false; // ジャンプしたので地面にいないとフラグを立てる
    }

    // プレイヤーの向きを更新するメソッド
    void UpdateFacingDirection(float horizontalInput)
    {
        if (horizontalInput < 0 && bIsFacingRight)
        {
            Flip();
        }
        else if (horizontalInput > 0 && !bIsFacingRight)
        {
            Flip();
        }
    }

    // プレイヤーの向きを反転するメソッド
    void Flip()
    {
        bIsFacingRight = !bIsFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    //--- 敵に接触時の処理をするメソッド ---
    void EnemyContact(Collision2D collision)
    {
        // プレイヤーの状態を被ダメージ状態に切り替え
        gameManager.SetPlayerState(GameManager.ePlayerState.TakeDamage);

        // 点滅処理
        StartCoroutine(BlinkEffect());

        // ダメージ減少処理
        gameManager.LoseLife();

        // 敵とぶつかった時に少し弾かれる処理
    }

    //--- 点滅処理 ---
    IEnumerator BlinkEffect()
    {
        float endTime = Time.time + fBlinkDuration;
        while (Time.time < endTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(fBlinkInterval);
        }
        // 点滅終了後にスプライトを表示
        spriteRenderer.enabled = true;

        // プレイヤー状態を通常に戻す
        gameManager.SetPlayerState(GameManager.ePlayerState.Normal);
    }

    //=== 衝突判定 処理 ===
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 地面に触れている時
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Scaffold") ||
            collision.gameObject.GetComponent<TilemapCollider2D>() != null)
        {
            bIsJump = false;
            bIsGround = true;
        }

        // 敵と触れている時
        if (!PlayerAttack.bIsAttack &&
            gameManager.CurrentPlayerState == 
            GameManager.ePlayerState.Normal &&
            collision.gameObject.CompareTag("Enemy"))
        {
            EnemyContact(collision);
        }
    }
}