using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    //=== �V�[�������[�h���郁�\�b�h ===
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //=== �V�[�������[�h����ۏ��������������郁�\�b�h ===
    public void InitalizeLoadScene(string sceneName)
    {
        GameManager.Instance.InitializeGame();
        SceneManager.LoadScene(sceneName);
    }

    //=== �����V�[�������g���C���郁�\�b�h ===
    public void RetryButton()
    {
        GameManager.Instance.ResetGame();
    }

    //=== �Q�[�����I�����郁�\�b�h ===
    public void EndButton()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();//�Q�[���v���C�I��
#endif
    }

    public void PlayMode()
    {
        GameManager.Instance.SetGameState(GameManager.eGameState.Playing);
    }
}
