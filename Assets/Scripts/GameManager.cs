using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //=== �񋓌^��` ===
    //--- �Q�[���̏�Ԃ��Ǘ�����---
    public enum eGameState
    {
        Playing = 0,
        Paused,
        GameOver,
        MAX_GAMESTATE,
    }

    //--- �v���C���[�̖��@�������Ǘ�����---
    public enum ePlayerAttributeState
    {
        Fire = 0,       // �� ����
        Water,          // �� ����
        Wind,           // �� ����
        Earth,          // �y ����
        MAX_ATTRIBUTE,  // �ő呮����
    }

    //--- �U�����@���Ǘ����� ---
    public enum ePlayerAttackMethod
    {
        Physics = 0,            // ���� �U��
        Magic,                  // ���@ �U��
        MAX_ATTACKMETHOD,       // �ő�U�����@
    }

    //--- �U���i�K()���Ǘ����� ---
    public enum ePlayerAttackStageState
    {
        Beginner = 0,           // ����
        Intermediate,           // ����
        Advanced,               // �㋉
        MAX_ATTACKSTAGE,        // �ő�U���i�K
    }

    //--- �V���O���g���C���X�^���X ---
    public static GameManager Instance { get; set; }

    //--- �Q�[����F�X�̏�Ԃƃv���C���[�f�[�^ ---
    public eGameState CurrentGameState { get; set; }
    public ePlayerAttributeState CurrentPlayerAttributeState { get; set; }
    public ePlayerAttackMethod CurrentPlayerAttackMethod { get; set; }
    public ePlayerAttackStageState CurrentPlayerAttackStage { get; set; }
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

    //=== �Q�[����Ԃ�ݒ肷�郁�\�b�h ===
    public void SetGameState(eGameState newState)
    {
        CurrentGameState = newState;
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
    //=== �v���C���[�̑�����ݒ肷�郁�\�b�h ===
    public void SetPlayerAttributeState(ePlayerAttributeState newState)
    {
        CurrentPlayerAttributeState = newState;

    }

    //=== �U�����@��ݒ肷�郁�\�b�h ===
    public void SetPlayerAttackMethodState(ePlayerAttackMethod newState)
    {
        CurrentPlayerAttackMethod = newState;
    }

    //=== �U���i�K��ݒ肷�郁�\�b�h ===
    public void SetPlayerAttackStageState(ePlayerAttackStageState newState)
    {
        CurrentPlayerAttackStage = newState;
    }

    //=== �Q�[���̏����� ===
    public void InitializeGame()
    {
        //--- ������� ������ ---
        PlayerScore = 0;
        PlayerLives = 3;

        //--- ��� ������ ---
        SetGameState(eGameState.Playing);                               // �Q�[�����
        SetPlayerAttackMethodState(ePlayerAttackMethod.Physics);        // �v���C���[ �U�� ���@
        SetPlayerAttackStageState(ePlayerAttackStageState.Beginner);    // �v���C���[ �U�� �i�K
        SetPlayerAttributeState(ePlayerAttributeState.Fire);            // �v���C���[ �U�� ����
    }

    //=== �Q�[�������Z�b�g���郁�\�b�h ===
    public void ResetGame()
    {
        InitializeGame();
        ReloadCurrentScene();
    }

    //=== �X�R�A��ǉ����郁�\�b�h ===
    public void AddScore(int amount)
    {
        // �X�R�A�X������
        PlayerScore += amount;
    }

    //=== ���C�t�����������郁�\�b�h ===
    public void LoseLife()
    {
        PlayerLives--;
        if (PlayerLives <= 0)
        {
            SetGameState(eGameState.GameOver);
        }
    }

    //=== �V�[�������[�h���郁�\�b�h ===
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //=== ���݂̃V�[���������[�h���郁�\�b�h ===
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}