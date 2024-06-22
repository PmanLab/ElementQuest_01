using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    //--- 格納用 ---
    private PlayerInputSystem playerInputSystem;
    
    //--- インスタンス ---
    private GameManager gameManager;

    //--- 行動用 ---
    private Vector2 inputAxis;

    //--- シリアライズ変数 ---
    [SerializeField, Header("移動スピード")] public float fWalkSpeed = 5.0f;
    [SerializeField, Header("走行スピード")] public float fRunSpeed = 10.0f;
    [SerializeField, Header("ジャンプ力")] public float fJumpForce = 10.0f;

    //--- リジットボディ ---
    private Rigidbody2D rb;

    //--- 検知フラグ ---
    public static bool isJump = false;
    public static bool isRun = false;
    public static bool isWalk = false;

    bool isGround = false;
    bool isFacingRight = false; // プレイヤーの向きを追跡するためのフラグ

    public static bool isPaused = false;

    //=== 初期化処理 ===
    void Start()
    {
        playerInputSystem = new PlayerInputSystem();        // インスタンス情報取得
        playerInputSystem.Enable();                         // 入力受付開始
        rb = GetComponent<Rigidbody2D>();                   // リジットボディを取得
        gameManager = GameManager.Instance;                 // GameManagerを取得
        Flip();                                             // 初期状態：右向き
        
    }

    //=== 更新処理 ===
    void Update()
    {


        inputAxis = playerInputSystem.Player.Move.ReadValue<Vector2>();

        // リセット状態
        isRun = false;
        isWalk = false;

        //--- ポーズ画面 ---
        if (playerInputSystem.Player.Pause.triggered && !isPaused)
        {
            isPaused = true;
            gameManager.SetGameState(GameManager.eGameState.Paused);
            Debug.Log("ポーズ画面を開きました。");
        }
        else if (playerInputSystem.Player.Pause.triggered && isPaused)
        {
            isPaused = false;
            gameManager.SetGameState(GameManager.eGameState.Playing);
            Debug.Log("ポーズ画面を閉じました、ゲームに戻ります。");
        }

        //=== 非ポーズ画面時 処理 ===
        if (!isPaused)
        {
            //--- 左右 移動(走り移動) ---
            if (inputAxis.x < 0 && playerInputSystem.Player.Run.IsPressed())
            {
                isRun = true;
                MoveLeft(fRunSpeed);
                //Debug.Log("左 ダッシュ移動");
            }

            else if (inputAxis.x < 0)
            {
                isWalk = true;
                MoveLeft(fWalkSpeed);
                //Debug.Log("左 移動");

            }

            else if (inputAxis.x > 0 && playerInputSystem.Player.Run.IsPressed())
            {
                isRun = true;
                MoveRight(fRunSpeed);
                //Debug.Log("右 ダッシュ移動");

            }

            else if (inputAxis.x > 0)
            {
                isWalk = true;
                MoveRight(fWalkSpeed);
                //Debug.Log("右 移動");
            }
            else
            {
                // 入力がない場合、速度をゼロにする
                StopMovement();
            }

            //--- ジャンプ ---
            if (playerInputSystem.Player.Jump.triggered && isGround)
            {
                isJump = true;
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
        isGround = false; // ジャンプしたので地面にいないとフラグを立てる
    }

    // プレイヤーの向きを更新するメソッド
    void UpdateFacingDirection(float horizontalInput)
    {
        if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
    }

    // プレイヤーの向きを反転するメソッド
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    //=== 衝突判定 処理 ===
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //--- 地面に触れている時 ---
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Scaffold") ||
            collision.gameObject.GetComponent<TilemapCollider2D>() != null)
        {
            isJump = false;
            isGround = true;
            //Debug.Log("地面に接地");
        }
    }
}
