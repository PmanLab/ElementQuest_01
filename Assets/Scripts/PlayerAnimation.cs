using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //--- 格納用 ---
    private Animator Anime;
    private GameManager gameManager;

    // ジャンプ中かどうかを判定するフラグ
    private bool hasJumped = false;

    //=== 初期化 処理 ===
    void Start()
    {
        gameManager = GameManager.Instance;         // GameManagerを取得
        Anime = GetComponent<Animator>(); // Animator情報を格納
    }

    //=== 更新 処理 ===
    void Update()
    {
        //=== アニメーション ===
        //--- 待機モーション ---
        switch (gameManager.CurrentPlayerAttackMethod)
        {
            //--- 物理 攻撃状態 ---
            case GameManager.ePlayerAttackMethod.Physics:
                Anime.SetBool("Idol_Normal", true);

                // 物理攻撃時はすべての属性アニメーションをfalseに設定
                Anime.SetBool("Idol_Fire", false);
                Anime.SetBool("Idol_Water", false);
                Anime.SetBool("Idol_Wind", false);
                Anime.SetBool("Idol_Earth", false);
                break;

            //--- 魔法 攻撃状態 ---
            case GameManager.ePlayerAttackMethod.Magic:
                switch (gameManager.CurrentPlayerAttributeState)
                {
                    // 火 属性
                    case GameManager.ePlayerAttributeState.Fire:
                        Anime.SetBool("Idol_Normal", false);
                        Anime.SetBool("Idol_Earth", false);
                        Anime.SetBool("Idol_Fire", true);
                        Anime.SetBool("Idol_Water", false);
                        Anime.SetBool("Idol_Wind", false);
                        break;
                    // 水 属性
                    case GameManager.ePlayerAttributeState.Water:
                        Anime.SetBool("Idol_Normal", false);
                        Anime.SetBool("Idol_Fire", false);
                        Anime.SetBool("Idol_Water", true);
                        Anime.SetBool("Idol_Wind", false);
                        Anime.SetBool("Idol_Earth", false);
                        break;
                    // 風 属性
                    case GameManager.ePlayerAttributeState.Wind:
                        Anime.SetBool("Idol_Normal", false);
                        Anime.SetBool("Idol_Water", false);
                        Anime.SetBool("Idol_Wind", true);
                        Anime.SetBool("Idol_Fire", false);
                        Anime.SetBool("Idol_Earth", false);
                        break;
                    // 土 属性
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
