using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //--- 格納用 ---
    private Animator Anime;

    // ジャンプ中かどうかを判定するフラグ
    private bool hasJumped = false;

    //=== 初期化 処理 ===
    void Start()
    {
        Anime = GetComponent<Animator>(); // Animator情報を格納
    }

    //=== 更新 処理 ===
    void Update()
    {
        //=== アニメーション ===
        //--- ジャンプ ---
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
