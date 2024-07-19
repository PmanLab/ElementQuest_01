using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
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
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();//ゲームプレイ終了
#endif
    }

    public void PlayMode()
    {
        GameManager.Instance.SetGameState(GameManager.eGameState.Playing);
    }
}
