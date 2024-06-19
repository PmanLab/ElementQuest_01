using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //--- ゲームの状態を管理する列挙型 ---
    public enum eGameState
    {
        Playing,
        Paused,
        GameOver
    }

    //--- シングルトンインスタンス ---
    public static GameManager Instance { get; set; }

    //--- ゲームの状態とプレイヤーデータ ---
    public eGameState CurrentState { get; set; }
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
        else
        {
            Destroy(gameObject);
        }
    }

    //=== 第二初期化 処理 ===
    void Start()
    {
        //--- ゲーム開始時の初期設定 ---
        Application.targetFrameRate = 60;
        InitializeGame();
    }

    //--- ゲーム状態を設定するメソッド ---
    public void SetGameState(eGameState newState)
    {
        CurrentState = newState;
        switch (newState)
        {
            case eGameState.Playing:
                Time.timeScale = 1f;
                break;
            case eGameState.Paused:
                Time.timeScale = 0f;
                break;
            case eGameState.GameOver:
                Time.timeScale = 0f;
                // Game Over時の追加処理をここに追加
                break;
        }
    }

    // ゲームの初期化
    public void InitializeGame()
    {
        PlayerScore = 0;
        PlayerLives = 3; // 初期ライフを設定
        SetGameState(eGameState.Playing);
        // 他の初期化処理をここに追加
    }

    // ゲームをリセットするメソッド
    public void ResetGame()
    {
        InitializeGame();
        ReloadCurrentScene();
    }

    // スコアを追加するメソッド
    public void AddScore(int amount)
    {
        PlayerScore += amount;
        // スコア更新に伴う処理をここに追加
    }

    // ライフを減少させるメソッド
    public void LoseLife()
    {
        PlayerLives--;
        if (PlayerLives <= 0)
        {
            SetGameState(eGameState.GameOver);
        }
    }

    // シーンをロードするメソッド
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // 現在のシーンをリロードするメソッド
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}