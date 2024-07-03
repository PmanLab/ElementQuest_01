using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //--- 格納用インスタンス ---
    private PanelManager panelManager;

    //=== 列挙型定義 ===
    //--- ゲームの状態を管理する---
    public enum eGameState
    {
        Playing = 0,
        Paused,
        GameOver,
        MAX_GAMESTATE,
    }

    //--- プレイヤーの状態を管理する ---
    public enum ePlayerState
    {
        Normal = 0,     // 通常
        TakeDamage,     // 被ダメージ時
        Muteki,         // 無敵
        Dead,           // 死亡
        MAX_PLAYERSTATE,// 最大プレイヤー状態

    }

    //--- プレイヤーの魔法属性を管理する---
    public enum ePlayerAttributeState
    {
        Fire = 0,       // 火 属性
        Water,          // 水 属性
        Wind,           // 風 属性
        Earth,          // 土 属性
        MAX_ATTRIBUTE,  // 最大属性数
    }

    //--- 攻撃方法を管理する ---
    public enum ePlayerAttackMethod
    {
        Physics = 0,            // 物理 攻撃
        Magic,                  // 魔法 攻撃
        MAX_ATTACKMETHOD,       // 最大攻撃方法
    }

    //--- 攻撃段階()を管理する ---
    public enum ePlayerAttackStageState
    {
        Beginner = 0,           // 初級
        Intermediate,           // 中級
        Advanced,               // 上級
        MAX_ATTACKSTAGE,        // 最大攻撃段階
    }

    //--- シングルトンインスタンス ---
    public static GameManager Instance { get; set; }

    //--- ゲームや色々の状態とプレイヤーデータ ---
    public eGameState CurrentGameState { get; set; }
    public ePlayerState CurrentPlayerState { get; set; }
    public ePlayerAttributeState CurrentPlayerAttributeState { get; set; }
    public ePlayerAttackMethod CurrentPlayerAttackMethod { get; set; }
    public ePlayerAttackStageState CurrentPlayerAttackStage { get; set; }
    public int PlayerScore { get; set; }
    public int PlayerLives { get; set; }

    //=== 第一 初期化 処理 ===
    void Awake()
    {

        //--- シーンロード時に破棄されないようにする ---
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    //=== 第二初期化 処理 ===
    void Start()
    {
        //--- ゲーム開始時の初期設定 ---
        Application.targetFrameRate = 60;

        //--- インスタンス情報取得 ---
        panelManager = GetComponent<PanelManager>();

        //--- 全初期化関数 ---
        InitializeGame();
    }

    //=== ゲーム状態を設定するメソッド ===
    public void SetGameState(eGameState newState)
    {
        CurrentGameState = newState;
        switch (newState)
        {
            case eGameState.Playing:
                Time.timeScale = 1f;
                PlayerController.bIsPaused = false;
                panelManager.ClosePausePanel();

                break;
            case eGameState.Paused:
                panelManager.OpenPausePanel();
                Time.timeScale = 0f;

                break;
            case eGameState.GameOver:
                Time.timeScale = 0f;
                // Game Over時の追加処理をここに追加
                panelManager.OpenGameOverPanel();
                

                break;
        }
    }

    public void SetPlayerState(ePlayerState newState)
    {
        CurrentPlayerState = newState; 
    }

    //=== プレイヤーの属性を設定するメソッド ===
    public void SetPlayerAttributeState(ePlayerAttributeState newState)
    {
        CurrentPlayerAttributeState = newState;

    }

    //=== 攻撃方法を設定するメソッド ===
    public void SetPlayerAttackMethodState(ePlayerAttackMethod newState)
    {
        CurrentPlayerAttackMethod = newState;
    }

    //=== 攻撃段階を設定するメソッド ===
    public void SetPlayerAttackStageState(ePlayerAttackStageState newState)
    {
        CurrentPlayerAttackStage = newState;
    }

    //=== ゲームの初期化 ===
    public void InitializeGame()
    {
        //--- 初期情報 初期化 ---
        PlayerScore = 0;
        PlayerLives = 5;

        //--- 状態 初期化 ---
        SetGameState(eGameState.Playing);                               // ゲーム状態
        SetPlayerState(ePlayerState.Normal);                            // プレイヤー 状態
        SetPlayerAttackMethodState(ePlayerAttackMethod.Physics);        // プレイヤー 攻撃 方法
        SetPlayerAttackStageState(ePlayerAttackStageState.Intermediate);    // プレイヤー 攻撃 段階
        SetPlayerAttributeState(ePlayerAttributeState.Fire);            // プレイヤー 攻撃 属性

    }

    //=== ゲームをリセットするメソッド ===
    public void ResetGame()
    {
        InitializeGame();
        ReloadCurrentScene();
    }

    //=== スコアを追加するメソッド ===
    public void AddScore(int amount)
    {
        // スコア更理処理
        PlayerScore += amount;
    }

    //=== ライフを減少させるメソッド ===
    public void LoseLife()
    {
        PlayerLives--;
        if (PlayerLives <= 0)
        {
            SetGameState(eGameState.GameOver);
        }
    }

    //=== 現在のシーンをリロードするメソッド ===
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}