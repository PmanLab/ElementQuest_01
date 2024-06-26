using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //--- �i�[�p ---
    private Animator Anime;
    private GameManager gameManager;

    //--- ���m�p�t���O ---
    public static bool bIsJump = false;              // �W�����v�A�j���[�V�����������肷��t���O

    //=== ������ ���� ===
    void Start()
    {
        gameManager = GameManager.Instance;         // GameManager���擾
        Anime = GetComponent<Animator>();           // Animator�����i�[
    }

    //=== �X�V ���� ===
    void Update()
    {
        //=== �v���C���[�A�j���[�V���� ===
        if(Anime != null)
        {
            //=== �ҋ@���[�V���� ===
            switch (gameManager.CurrentPlayerAttackMethod)
            {
                //--- ���� �ҋ@��� ---
                case GameManager.ePlayerAttackMethod.Physics:
                    if (!Anime.GetBool("Idol_Normal"))
                    {
                        Anime.SetBool("Idol_Fire", false);
                        Anime.SetBool("Idol_Water", false);
                        Anime.SetBool("Idol_Wind", false);
                        Anime.SetBool("Idol_Earth", false);
                        Anime.SetBool("Idol_Normal", true);
                    }

                    break;


                //--- �e���� �ҋ@��� ---
                case GameManager.ePlayerAttackMethod.Magic:
                    if (Anime.GetBool("Idol_Normal"))
                    { Anime.SetBool("Idol_Normal", false); }
                    else
                    {
                        switch (gameManager.CurrentPlayerAttributeState)
                        {
                            // �� ����
                            case GameManager.ePlayerAttributeState.Fire:
                                Anime.SetBool("Idol_Earth", false);
                                Anime.SetBool("Idol_Fire", true);
                                break;
                            // �� ����
                            case GameManager.ePlayerAttributeState.Water:
                                Anime.SetBool("Idol_Fire", false);
                                Anime.SetBool("Idol_Water", true);
                                break;
                            // �� ����
                            case GameManager.ePlayerAttributeState.Wind:
                                Anime.SetBool("Idol_Water", false);
                                Anime.SetBool("Idol_Wind", true);
                                break;
                            // �y ����
                            case GameManager.ePlayerAttributeState.Earth:
                                Anime.SetBool("Idol_Wind", false);
                                Anime.SetBool("Idol_Earth", true);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
            }


            //=== �W�����v�A�j���[�V���� ===
            if (!bIsJump && PlayerController.bIsJump)
            {
                switch (gameManager.CurrentPlayerAttackMethod)
                {
                    //--- ���� �U����� ---
                    case GameManager.ePlayerAttackMethod.Physics:
                        // �����U�����͂��ׂĂ̑����A�j���[�V������false�ɐݒ�
                        Anime.SetBool("Jump_Normal", true);
                        bIsJump = true;

                        break;

                    //--- ���@ �U����� ---
                    case GameManager.ePlayerAttackMethod.Magic:
                        switch (gameManager.CurrentPlayerAttributeState)
                        {
                            // �� ����
                            case GameManager.ePlayerAttributeState.Fire:
                                Anime.SetBool("Jump_Fire", true);
                                bIsJump = true;

                                break;
                            // �� ����
                            case GameManager.ePlayerAttributeState.Water:
                                Anime.SetBool("Jump_Water", true);
                                bIsJump = true;

                                break;
                            // �� ����
                            case GameManager.ePlayerAttributeState.Wind:
                                Anime.SetBool("Jump_Wind", true);
                                bIsJump = true;

                                break;
                            // �y ����
                            case GameManager.ePlayerAttributeState.Earth:
                                Anime.SetBool("Jump_Earth", true);
                                bIsJump = true;

                                break;
                            default:
                                break;
                        }

                        break;
                }
            }
            else if (bIsJump && !PlayerController.bIsJump)
            {
                switch (gameManager.CurrentPlayerAttackMethod)
                {
                    //--- ���� �U����� ---
                    case GameManager.ePlayerAttackMethod.Physics:
                        // �����U�����͂��ׂĂ̑����A�j���[�V������false�ɐݒ�
                        Anime.SetBool("Jump_Normal", false);
                        bIsJump = false;

                        break;

                    //--- ���@ �U����� ---
                    case GameManager.ePlayerAttackMethod.Magic:
                        switch (gameManager.CurrentPlayerAttributeState)
                        {
                            // �� ����
                            case GameManager.ePlayerAttributeState.Fire:
                                Anime.SetBool("Jump_Fire", false);
                                bIsJump = false;

                                break;
                            // �� ����
                            case GameManager.ePlayerAttributeState.Water:
                                Anime.SetBool("Jump_Water", false);
                                bIsJump = false;

                                break;
                            // �� ����
                            case GameManager.ePlayerAttributeState.Wind:
                                Anime.SetBool("Jump_Wind", false);
                                bIsJump = false;

                                break;
                            // �y ����
                            case GameManager.ePlayerAttributeState.Earth:
                                Anime.SetBool("Jump_Earth", false);
                                bIsJump = false;

                                break;
                            default:
                                break;
                        }

                        break;
                }
            }
        }
        else
        {
            Debug.Log("PlayerAnimation�FAnimetor��񂪂���܂���");
        }
    }

    //=== ���상�\�b�h ===
    //--- ���� �U���A�j���[�V�������I���ɂ���֐�
    public void PlayerPhysicsAttackAnimation()
    {
        //--- ���� �U����� ---
        Anime.SetBool("Attack_Physics", true);
    }

    //--- ���@ �U���A�j���[�V�������I���ɂ���֐�
    public void PlayerMagicAttackAnimation()
    {
        switch (gameManager.CurrentPlayerAttributeState)
        {
            // �� ����
            case GameManager.ePlayerAttributeState.Fire:
                Anime.SetBool("Attack_Magic_Fire", true);

                break;
            // �� ����
            case GameManager.ePlayerAttributeState.Water:
                Anime.SetBool("Attack_Magic_Water", true);

                break;
            // �� ����
            case GameManager.ePlayerAttributeState.Wind:
                Anime.SetBool("Attack_Magic_Wind", true);

                break;
            // �y ����
            case GameManager.ePlayerAttributeState.Earth:
                Anime.SetBool("Attack_Magic_Earth", true);

                break;
            default:
                break;
        }
    }

    //--- �U���A�j���[�V�������I�t�ɂ���֐� ---
    public void PlayerAttackAnimationEnd()
    {
        if (Anime.GetBool("Attack_Physics") ||
            Anime.GetBool("Attack_Magic_Fire") ||
            Anime.GetBool("Attack_Magic_Water") ||
            Anime.GetBool("Attack_Magic_Wind") ||
            Anime.GetBool("Attack_Magic_Earth"))
        {
            PlayerAttackPhysicsAnimationEnd();
            PlayerAttackFireAnimationEnd();
            PlayerAttackWindAnimationEnd();
            PlayerAttackWaterAnimationEnd();
            PlayerAttackEarthAnimationEnd();
        }
    }

    public void PlayerAttackPhysicsAnimationEnd()
    {
        Anime.SetBool("Attack_Physics", false);

    }

    public void PlayerAttackFireAnimationEnd()
    {
        Anime.SetBool("Attack_Magic_Fire", false);

    }

    public void PlayerAttackWaterAnimationEnd()
    {
        Anime.SetBool("Attack_Magic_Water", false);

    }

    public void PlayerAttackWindAnimationEnd()
    {
        Anime.SetBool("Attack_Magic_Wind", false);

    }

    public void PlayerAttackEarthAnimationEnd()
    {
        Anime.SetBool("Attack_Magic_Earth", false);
    }
}