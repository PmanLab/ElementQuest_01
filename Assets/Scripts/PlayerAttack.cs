using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //--- �i�[�p�C���X�^���X ---
    private PlayerInputSystem playerInputSystem;
    private GameManager gameManager;
    private PlayerMagicAttack playerMagicAttack;
    private PlayerAnimation playerAnimation;

    //--- �V���A���C�Y�ϐ� ---
    [SerializeField, Header("��{ �U����")] public static float fAttackLevel = 5.0f;

    //--- ���m�p�t���O ---
    public static bool isAttack = false;    // �U�����m�p


    //=== ���������� ===
    void Start()
    {
        playerInputSystem = new PlayerInputSystem();                // �C���X�^���X���擾
        playerInputSystem.Enable();                                 // ���͎�t�J�n
        gameManager = GameManager.Instance;                         // GameManager���擾
        playerAnimation = GetComponent<PlayerAnimation>();          // 
        playerMagicAttack = GetComponent<PlayerMagicAttack>();      //

    }

    //=== �X�V���� ===
    void Update()
    {
        //=== ��|�[�Y��ʎ� & ��W�����v�� ���� ===
        //if (!PlayerController.isPaused && !PlayerAnimation.isJump)
        if (!PlayerController.isPaused)
        {
            if (!PlayerAnimation.isJump)
            {
                //--- �U�����@�ύX ---
                ChangeAttack();


                //--- �����ύX ---
                if (gameManager.CurrentPlayerAttackMethod ==
                    GameManager.ePlayerAttackMethod.Magic)
                { ChangeChangAttribute(); }
            }

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

            isAttack = true;    // �U�� ���m�t���OON

            if (isAttack)
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
                    //--- ���@ �U����� ---
                    case GameManager.ePlayerAttackMethod.Magic:
                        MagicAttack();

                        break;
                }

            }

        }

        if(!isAttack)
        {
            playerAnimation.PlayerAttackAnimationEnd();
        }
    }

    //--- �U���I���t���O���m ---
    void AttackEnd()
    {
        isAttack = false;
    }

    //--- �����U�� ---
    void PhysicsAttack()
    {
        playerAnimation.PlayerPhysicsAttackAnimation(); // �U���A�j���[�V����
    }

    //--- ���@�U�� ---
    void MagicAttack()
    {
        playerAnimation.PlayerMagicAttackAnimation();   // �U���A�j���[�V����

        //--- �������� ---
        switch (gameManager.CurrentPlayerAttributeState)
        {
            // �� ����
            case GameManager.ePlayerAttributeState.Fire:
                //--- �U���i�K ���� ---
                switch(gameManager.CurrentPlayerAttackStage)
                {
                    case GameManager.ePlayerAttackStageState.Beginner:
                        playerMagicAttack.FireBeginnerAttack();
                        break;
                    case GameManager.ePlayerAttackStageState.Intermediate:
                        playerMagicAttack.FireIntermediateAttack();

                        break;
                    case GameManager.ePlayerAttackStageState.Advanced:
                        playerMagicAttack.FireAdvancedAttack();

                        break;
                }

                break;
            // �� ����
            case GameManager.ePlayerAttributeState.Water:
                //--- �U���i�K ���� ---
                switch (gameManager.CurrentPlayerAttackStage)
                {
                    case GameManager.ePlayerAttackStageState.Beginner:
                        playerMagicAttack.WaterBeginnerAttack();
                        
                        break;
                    case GameManager.ePlayerAttackStageState.Intermediate:
                        playerMagicAttack.WaterIntermediateAttack();

                        break;
                    case GameManager.ePlayerAttackStageState.Advanced:
                        playerMagicAttack.WaterAdvancedAttack();

                        break;
                }

                break;
            // �� ����
            case GameManager.ePlayerAttributeState.Wind:
                //--- �U���i�K ���� ---
                switch (gameManager.CurrentPlayerAttackStage)
                {
                    case GameManager.ePlayerAttackStageState.Beginner:
                        playerMagicAttack.WindBeginnerAttack();

                        break;
                    case GameManager.ePlayerAttackStageState.Intermediate:
                        playerMagicAttack.WindIntermediateAttack();

                        break;
                    case GameManager.ePlayerAttackStageState.Advanced:
                        playerMagicAttack.WindAdvancedAttack();

                        break;
                }

                break;
            // �y ����
            case GameManager.ePlayerAttributeState.Earth:
                //--- �U���i�K ���� ---
                switch (gameManager.CurrentPlayerAttackStage)
                {
                    case GameManager.ePlayerAttackStageState.Beginner:
                        playerMagicAttack.EarthBeginnerAttack();

                        break;
                    case GameManager.ePlayerAttackStageState.Intermediate:
                        playerMagicAttack.EarthIntermediateAttack();

                        break;
                    case GameManager.ePlayerAttackStageState.Advanced:
                        playerMagicAttack.EarthAdvancedAttack();

                        break;
                }

                break;
            default:
                break;
        }
    }
}