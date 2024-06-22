using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //--- �i�[�p�C���X�^���X ---
    private PlayerInputSystem playerInputSystem;
    private GameManager gameManager;

    //--- �V���A���C�Y�ϐ� ---
    [SerializeField, Header("��{ �U����")] public float fAttackLevel = 5.0f;

    //--- ���m�p�t���O ---
    

    //=== ���������� ===
    void Start()
    {
        playerInputSystem = new PlayerInputSystem();        // �C���X�^���X���擾
        playerInputSystem.Enable();                         // ���͎�t�J�n
        gameManager = GameManager.Instance;                 // GameManager���擾
    }

    //=== �X�V���� ===
    void Update()
    {
        //=== ��|�[�Y��ʎ� ���� ===
        if (!PlayerController.isPaused)
        {
            //--- �U�����@�ύX ---
            ChangeAttack();
            //--- �����ύX ---
            ChangeChangAttribute();
            //--- �U������ ---
            Attack();

        }
    }


    //=== ���상�\�b�h ===
    //--- �U�����@�ύX ---
    void ChangeAttack()
    {
        //--- �U�����@�ύX ---
        if (playerInputSystem.Player.ChangeAttackMethod.triggered)
        {
            switch (gameManager.CurrentPlayerAttackMethod)
            {
                // ����
                case GameManager.ePlayerAttackMethod.Physics:
                    gameManager.SetPlayerAttackMethodState(
                        GameManager.ePlayerAttackMethod.Magic);

                    break;
                // ���@
                case GameManager.ePlayerAttackMethod.Magic:
                    gameManager.SetPlayerAttackMethodState(
                        GameManager.ePlayerAttackMethod.Physics);

                    break;
            }


            Debug.Log("�U�� ���@���y " + gameManager.CurrentPlayerAttackMethod + " �z�ɕύX���܂���");

        }
    }
    
    //--- �U�������ύX ---
    void ChangeChangAttribute()
    {
        //--- �����ύX ---
        if (playerInputSystem.Player.ChangAttribute.triggered)
        {
            //--- �ύX���� ---
            switch (gameManager.CurrentPlayerAttributeState)
            {
                // �� ����
                case GameManager.ePlayerAttributeState.Fire:
                    gameManager.SetPlayerAttributeState(
                        GameManager.ePlayerAttributeState.Water);

                    break;
                // �� ����
                case GameManager.ePlayerAttributeState.Water:
                    gameManager.SetPlayerAttributeState(
                        GameManager.ePlayerAttributeState.Wind);

                    break;
                // �� ����
                case GameManager.ePlayerAttributeState.Wind:
                    gameManager.SetPlayerAttributeState(
                        GameManager.ePlayerAttributeState.Earth);

                    break;
                // �y ����
                case GameManager.ePlayerAttributeState.Earth:
                    gameManager.SetPlayerAttributeState(
                        GameManager.ePlayerAttributeState.Fire);

                    break;
                default:
                    break;
            }

            Debug.Log("�U�� �������y " + gameManager.CurrentPlayerAttributeState + " �z�ɕύX���܂���");

        }
    }

    //--- �U������ ---
    void Attack()
    {
        //--- �U������ ---
        if (playerInputSystem.Player.Attack.triggered)
        {
            Debug.Log("�U�� ���@�y " + gameManager.CurrentPlayerAttackMethod + " �z");
            Debug.Log("�U�� �����y " + gameManager.CurrentPlayerAttributeState + " �z");
            Debug.Log("�U�� �i�K�y " + gameManager.CurrentPlayerAttackStage + " �z");

            //--- �U�����@ ���菈�� ---
            switch (gameManager.CurrentPlayerAttackMethod)
            {
                // �����U�� ����
                case GameManager.ePlayerAttackMethod.Physics:
                    PhysicsAttack();

                    break;
                // ���@�U�� ����
                case GameManager.ePlayerAttackMethod.Magic:
                    MagicAttack();

                    break;
                default:
                    break;
            }
        }
    }

    //--- �����U�� ---
    void PhysicsAttack()
    {

    }

    //--- ���@�U�� ---
    void MagicAttack()
    {
        //--- �U���i�K ���菈�� ---
        switch (gameManager.CurrentPlayerAttackStage)
        {
            // ����
            case GameManager.ePlayerAttackStageState.Beginner:
                BeginnerMagicAttack();
                break;
            // ����
            case GameManager.ePlayerAttackStageState.Intermediate:
                IntermediateMagicAttack();
                break;
            // �㋉
            case GameManager.ePlayerAttackStageState.Advanced:
                AdvancedMagic();
                break;
            default:
                break;
        }

    }

    //--- �������@ ---
    void BeginnerMagicAttack()
    {
        //--- �������� ---
        switch (gameManager.CurrentPlayerAttributeState)
        {
            // �� ����
            case GameManager.ePlayerAttributeState.Fire:

                break;
            // �� ����
            case GameManager.ePlayerAttributeState.Water:

                break;
            // �� ����
            case GameManager.ePlayerAttributeState.Wind:

                break;
            // �y ����
            case GameManager.ePlayerAttributeState.Earth:

                break;
            default:
                break;
        }
    }

    //--- �������@ ---
    void IntermediateMagicAttack()
    {
        //--- �������� ---
        switch (gameManager.CurrentPlayerAttributeState)
        {
            // �� ����
            case GameManager.ePlayerAttributeState.Fire:

                break;
            // �� ����
            case GameManager.ePlayerAttributeState.Water:

                break;
            // �� ����
            case GameManager.ePlayerAttributeState.Wind:

                break;
            // �y ����
            case GameManager.ePlayerAttributeState.Earth:

                break;
            default:
                break;
        }
    }

    //--- �㋉���@ ---
    void AdvancedMagic()
    {
        //--- �������� ---
        switch (gameManager.CurrentPlayerAttributeState)
        {
            // �� ����
            case GameManager.ePlayerAttributeState.Fire:

                break;
            // �� ����
            case GameManager.ePlayerAttributeState.Water:

                break;
            // �� ����
            case GameManager.ePlayerAttributeState.Wind:

                break;
            // �y ����
            case GameManager.ePlayerAttributeState.Earth:

                break;
            default:
                break;
        }
    }
}
