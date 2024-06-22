using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //--- �i�[�p�C���X�^���X ---
    PlayerController player;

    //--- �ϐ��錾 ---
    GameObject playerObj;           // PlayerObject�i�[�p
    Transform playerTransform;      // PlayerObject��Transform�i�[�p


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

    //=== ���상�\�b�h ===
    //--- �J�����Ǐ]���� ---
    void MoveCamera()
    {
        // �J�����̈ʒu���v���C���[��X���W�ɒǏ]������iY����Z���͂��̂܂܁j
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
