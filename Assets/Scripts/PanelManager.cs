using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    //=== 変数宣言 ===
    //--- 格納用インスタンス ---
    private GameManager gameManager;

    //--- オブジェクト ---
    [SerializeField, Header("メニュー 画面")] public GameObject menuPanel;
    [SerializeField, Header("ポーズ 画面")] public GameObject pausePanel;
    [SerializeField, Header("コンフィグ 画面")] public GameObject configPanel;
    [SerializeField, Header("ゲームオーバー 画面")] public GameObject gameOverPanel;

    private GameObject CreatePanel;

    //=== 自作メソッド ===
    //--- ポーズ画面 表示メソッド ---
    public void OpenPausePanel()
    {
        CreatePanel = Instantiate(pausePanel);
    }

    //--- ポーズ画面 非表示メソッド ---
    public void ClosePausePanel()
    {
        Destroy(CreatePanel);
    }

    //--- ゲームオーバー画面 表示メソッド ---
    public void OpenGameOverPanel()
    {
        CreatePanel = Instantiate(gameOverPanel);
    }

    //--- ゲームオーバー画面 非表示メソッド ---
    public void CloseGameOverPanel()
    {
        Destroy(CreatePanel);
    }


}
