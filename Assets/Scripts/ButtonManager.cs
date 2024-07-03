using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    //=== シーンをロードするメソッド ===
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //=== シーンをロードする際初期化処理もするメソッド ===
    public void InitalizeLoadScene(string sceneName)
    {
        GameManager.Instance.InitializeGame();
        SceneManager.LoadScene(sceneName);
    }

    //=== 同じシーンをリトライするメソッド ===
    public void RetryButton()
    {
        GameManager.Instance.ResetGame();
    }

    //=== ゲームを終了するメソッド ===
    public void EndButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void PlayMode()
    {
        GameManager.Instance.SetGameState(GameManager.eGameState.Playing);
    }
}
