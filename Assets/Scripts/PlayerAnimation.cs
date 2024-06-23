using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //--- �i�[�p ---
    private Animator Anime;
    private GameManager gameManager;

    // �W�����v�����ǂ����𔻒肷��t���O
    public static bool isJump = false;

    //=== ������ ���� ===
    void Start()
    {
        gameManager = GameManager.Instance;         // GameManager���擾
        Anime = GetComponent<Animator>();           // Animator�����i�[
    }

    //=== �X�V ���� ===
    void Update()
    {
        //=== �A�j���[�V���� ===
        //--- �ҋ@���[�V���� ---
        switch (gameManager.CurrentPlayerAttackMethod)
        {
            //--- ���� �U����� ---
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


            //--- ���@ �U����� ---
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

        //--- �W�����v ---
        if (PlayerController.isJump == true && !isJump)
        {
            switch (gameManager.CurrentPlayerAttackMethod)
            {
                //--- ���� �U����� ---
                case GameManager.ePlayerAttackMethod.Physics:
                    // �����U�����͂��ׂĂ̑����A�j���[�V������false�ɐݒ�
                    Anime.SetBool("Jump_Normal", true);
                    isJump = true;

                    break;

                //--- ���@ �U����� ---
                case GameManager.ePlayerAttackMethod.Magic:
                    switch (gameManager.CurrentPlayerAttributeState)
                    {
                        // �� ����
                        case GameManager.ePlayerAttributeState.Fire:
                            Anime.SetBool("Jump_Fire", true);
                            isJump = true;

                            break;
                        // �� ����
                        case GameManager.ePlayerAttributeState.Water:
                            Anime.SetBool("Jump_Water", true);
                            isJump = true;

                            break;
                        // �� ����
                        case GameManager.ePlayerAttributeState.Wind:
                            Anime.SetBool("Jump_Wind", true);
                            isJump = true;

                            break;
                        // �y ����
                        case GameManager.ePlayerAttributeState.Earth:
                            Anime.SetBool("Jump_Earth", true);
                            isJump = true;

                            break;
                        default:
                            break;
                    }

                    break;
            }
        }
        else if (isJump && !PlayerController.isJump)
        {
            switch (gameManager.CurrentPlayerAttackMethod)
            {
                //--- ���� �U����� ---
                case GameManager.ePlayerAttackMethod.Physics:
                    // �����U�����͂��ׂĂ̑����A�j���[�V������false�ɐݒ�
                    Anime.SetBool("Jump_Normal", false);
                    isJump = false;

                    break;

                //--- ���@ �U����� ---
                case GameManager.ePlayerAttackMethod.Magic:
                    switch (gameManager.CurrentPlayerAttributeState)
                    {
                        // �� ����
                        case GameManager.ePlayerAttributeState.Fire:
                            Anime.SetBool("Jump_Fire", false);
                            isJump = false;

                            break;
                        // �� ����
                        case GameManager.ePlayerAttributeState.Water:
                            Anime.SetBool("Jump_Water", false);
                            isJump = false;

                            break;
                        // �� ����
                        case GameManager.ePlayerAttributeState.Wind:
                            Anime.SetBool("Jump_Wind", false);
                            isJump = false;

                            break;
                        // �y ����
                        case GameManager.ePlayerAttributeState.Earth:
                            Anime.SetBool("Jump_Earth", false);
                            isJump = false;

                            break;
                        default:
                            break;
                    }

                    break;
            }
        }
    }
}