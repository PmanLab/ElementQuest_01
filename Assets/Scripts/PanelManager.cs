using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    //=== �ϐ��錾 ===
    //--- �i�[�p�C���X�^���X ---
    private GameManager gameManager;

    //--- �I�u�W�F�N�g ---
    [SerializeField, Header("���j���[ ���")] public GameObject menuPanel;
    [SerializeField, Header("�|�[�Y ���")] public GameObject pausePanel;
    [SerializeField, Header("�R���t�B�O ���")] public GameObject configPanel;
    [SerializeField, Header("�Q�[���I�[�o�[ ���")] public GameObject gameOverPanel;

    private GameObject CreatePanel;

    //=== ���상�\�b�h ===
    //--- �|�[�Y��� �\�����\�b�h ---
    public void OpenPausePanel()
    {
        CreatePanel = Instantiate(pausePanel);
    }

    //--- �|�[�Y��� ��\�����\�b�h ---
    public void ClosePausePanel()
    {
        Destroy(CreatePanel);
    }

    //--- �Q�[���I�[�o�[��� �\�����\�b�h ---
    public void OpenGameOverPanel()
    {
        CreatePanel = Instantiate(gameOverPanel);
    }

    //--- �Q�[���I�[�o�[��� ��\�����\�b�h ---
    public void CloseGameOverPanel()
    {
        Destroy(CreatePanel);
    }


}
