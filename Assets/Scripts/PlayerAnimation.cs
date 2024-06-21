using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //--- �i�[�p ---
    private Animator Anime;

    // �W�����v�����ǂ����𔻒肷��t���O
    private bool hasJumped = false;

    //=== ������ ���� ===
    void Start()
    {
        Anime = GetComponent<Animator>(); // Animator�����i�[
    }

    //=== �X�V ���� ===
    void Update()
    {
        //=== �A�j���[�V���� ===
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
