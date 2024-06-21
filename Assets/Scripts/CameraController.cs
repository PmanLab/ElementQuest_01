using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // �v���C���[�I�u�W�F�N�g���i�[���邽�߂̕ϐ�
    GameObject playerObj;

    // �v���C���[��PlayerController�R���|�[�l���g���i�[���邽�߂̕ϐ�
    PlayerController player;

    // �v���C���[�I�u�W�F�N�g��Transform���i�[���邽�߂̕ϐ�
    Transform playerTransform;

    //=== ���������� ===
    void Start()
    {
        // �^�O��"Player"�̃I�u�W�F�N�g���������Ď擾
        playerObj = GameObject.FindGameObjectWithTag("Player");

        // �v���C���[�I�u�W�F�N�g��PlayerController�R���|�[�l���g���擾
        player = playerObj.GetComponent<PlayerController>();

        // �v���C���[�I�u�W�F�N�g��Transform���擾
        playerTransform = playerObj.transform;
    }

    //=== �X�V���� ===
    void LateUpdate()
    {
        // �J�������v���C���[�ɒǏ]�����鏈�����Ăяo��
        MoveCamera();
    }

    //=== �J�����Ǐ]���� ===
    void MoveCamera()
    {
        // �J�����̈ʒu���v���C���[��X���W�ɒǏ]������iY����Z���͂��̂܂܁j
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
