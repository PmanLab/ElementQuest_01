using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //--- �i�[�p ---
    private Animator Anime;
    private GameManager gameManager;

    // �W�����v�����ǂ����𔻒肷��t���O
    private bool hasJumped = false;

    //=== ������ ���� ===
    void Start()
    {
        gameManager = GameManager.Instance;         // GameManager���擾
        Anime = GetComponent<Animator>(); // Animator�����i�[
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
                Anime.SetBool("Idol_Normal", true);

                // �����U�����͂��ׂĂ̑����A�j���[�V������false�ɐݒ�
                Anime.SetBool("Idol_Fire", false);
                Anime.SetBool("Idol_Water", false);
                Anime.SetBool("Idol_Wind", false);
                Anime.SetBool("Idol_Earth", false);
                break;

            //--- ���@ �U����� ---
            case GameManager.ePlayerAttackMethod.Magic:
                switch (gameManager.CurrentPlayerAttributeState)
                {
                    // �� ����
                    case GameManager.ePlayerAttributeState.Fire:
                        Anime.SetBool("Idol_Normal", false);
                        Anime.SetBool("Idol_Earth", false);
                        Anime.SetBool("Idol_Fire", true);
                        Anime.SetBool("Idol_Water", false);
                        Anime.SetBool("Idol_Wind", false);
                        break;
                    // �� ����
                    case GameManager.ePlayerAttributeState.Water:
                        Anime.SetBool("Idol_Normal", false);
                        Anime.SetBool("Idol_Fire", false);
                        Anime.SetBool("Idol_Water", true);
                        Anime.SetBool("Idol_Wind", false);
                        Anime.SetBool("Idol_Earth", false);
                        break;
                    // �� ����
                    case GameManager.ePlayerAttributeState.Wind:
                        Anime.SetBool("Idol_Normal", false);
                        Anime.SetBool("Idol_Water", false);
                        Anime.SetBool("Idol_Wind", true);
                        Anime.SetBool("Idol_Fire", false);
                        Anime.SetBool("Idol_Earth", false);
                        break;
                    // �y ����
                    case GameManager.ePlayerAttributeState.Earth:
                        Anime.SetBool("Idol_Normal", false);
                        Anime.SetBool("Idol_Wind", false);
                        Anime.SetBool("Idol_Earth", true);
                        Anime.SetBool("Idol_Fire", false);
                        Anime.SetBool("Idol_Water", false);
                        break;
                    default:
                        break;
                }

                break;
        }

        //--- �W�����v ---
        if (PlayerController.isJump == true && !hasJumped)
        {
            Anime.SetBool("Jump", true);
            hasJumped = true;
        }
        else if (hasJumped && !PlayerController.isJump)
        {
            Anime.SetBool("Jump", false);
            hasJumped = false;
        }
    }
}
