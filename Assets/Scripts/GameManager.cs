using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //--- �Q�[���̏�Ԃ��Ǘ�����񋓌^ ---
    public enum eGameState
    {
        Playing,
        Paused,
        GameOver
    }

    //--- �V���O���g���C���X�^���X ---
    public static GameManager Instance { get; set; }

    //--- �Q�[���̏�Ԃƃv���C���[�f�[�^ ---
    public eGameState CurrentState { get; set; }
    public int PlayerScore { get; set; }
    public int PlayerLives { get; set; }

    //=== ��� ������ ���� ===
    void Awake()
    {

        //--- �V�[�����[�h���ɔj������Ȃ��悤�ɂ��� ---
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

    //=== ��񏉊��� ���� ===
    void Start()
    {
        //--- �Q�[���J�n���̏����ݒ� ---
        Application.targetFrameRate = 60;
        InitializeGame();
    }

    //--- �Q�[����Ԃ�ݒ肷�郁�\�b�h ---
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
                // Game Over���̒ǉ������������ɒǉ�
                break;
        }
    }

    // �Q�[���̏�����
    public void InitializeGame()
    {
        PlayerScore = 0;
        PlayerLives = 3; // �������C�t��ݒ�
        SetGameState(eGameState.Playing);
        // ���̏����������������ɒǉ�
    }

    // �Q�[�������Z�b�g���郁�\�b�h
    public void ResetGame()
    {
        InitializeGame();
        ReloadCurrentScene();
    }

    // �X�R�A��ǉ����郁�\�b�h
    public void AddScore(int amount)
    {
        PlayerScore += amount;
        // �X�R�A�X�V�ɔ��������������ɒǉ�
    }

    // ���C�t�����������郁�\�b�h
    public void LoseLife()
    {
        PlayerLives--;
        if (PlayerLives <= 0)
        {
            SetGameState(eGameState.GameOver);
        }
    }

    // �V�[�������[�h���郁�\�b�h
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // ���݂̃V�[���������[�h���郁�\�b�h
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}